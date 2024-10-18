using LeaveManagementSystem.Application.Models.LeaveRequests;
using LeaveManagementSystem.Application.Services.LeaveAllocations;
using LeaveManagementSystem.Application.Services.Periods;
using LeaveManagementSystem.Application.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Services.LeaveRequests;

public class LeaveRequestsService(IMapper _mapper,
    IUserService _userService,
    ApplicationDbContext _context, IPeriodsService _periodsService,
    ILeaveAllocationsService _leaveAllocationsService) : ILeaveRequestsService
{
    public async Task CancelLeaveRequest(int leaveRequestId)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestSatusId = (int)LeaveRequestStatusEnum.Canceled;

        // Restore canceled days to allocation
        await UpdateAllocationDays(leaveRequest, false);
        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        // Map Data to leave requset data model
        var leaveRequest = _mapper.Map<LeaveRequest>(model);
        // Get logged in employee ID
        var user = await _userService.GetLoggedInUser();
        leaveRequest.EmployeeId = user.Id;
        // Set LeaveRequestStatusId to pending
        leaveRequest.LeaveRequestSatusId = (int)LeaveRequestStatusEnum.Pending;
        // Save leave request
        _context.Add(leaveRequest);

        // Deduct allaction based on requested days
        await UpdateAllocationDays(leaveRequest, true);
        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType).ToListAsync();
        var approvedLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestSatusId ==
        (int)LeaveRequestStatusEnum.Approved);
        var pendingLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestSatusId ==
        (int)LeaveRequestStatusEnum.Pending);
        var declinedLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestSatusId ==
        (int)LeaveRequestStatusEnum.Declined);

        var leaveRequestModels = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
        {
            StartDate = q.StartDate,
            EndDate = q.EndDate,
            Id = q.Id,
            LeaveType = q.LeaveType.Name,
            LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestSatusId,
            NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
        }).ToList();

        var model = new EmployeeLeaveRequestListVM
        {
            ApprovedRequests = approvedLeaveRequestsCount,
            PendingRequests = pendingLeaveRequestsCount,
            DeclinedRequests = declinedLeaveRequestsCount,
            TotalRequests = leaveRequests.Count(),
            LeaveRequests = leaveRequestModels
        };

        return model;
    }

    public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
    {
        var user = await _userService.GetLoggedInUser();
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .Where(q => q.EmployeeId == user.Id).ToListAsync();

        var model = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
        {
            StartDate = q.StartDate,
            EndDate = q.EndDate,
            Id = q.Id,
            LeaveType = q.LeaveType.Name,
            LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestSatusId,
            NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
        }).ToList();

        return model;
    }

    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userService.GetLoggedInUser();
        var period = await _periodsService.GetCurrentPeriod();
        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context.LeaveAllocations.
            FirstOrDefaultAsync(q => q.LeaveTypeId == model.LeaveTypeId
            && q.EmployeeId == user.Id
            && q.PeriodId == period.Id);

        return allocation.Days < numberOfDays;
    }

    public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
        var user = await _userService.GetLoggedInUser();
        var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;

        leaveRequest.LeaveRequestSatusId = approved
            ? (int)LeaveRequestStatusEnum.Approved
            : (int)LeaveRequestStatusEnum.Declined;

        leaveRequest.ReviewerId = user.Id;

        if (!approved)
        {
            await UpdateAllocationDays(leaveRequest, false);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstAsync(q => q.Id == id);
        var user = await _userService.GetUserById(leaveRequest.EmployeeId);

        var model = new ReviewLeaveRequestVM
        {
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            NumberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber,
            LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestSatusId,
            Id = leaveRequest.Id,
            LeaveType = leaveRequest.LeaveType.Name,
            RequestComments = leaveRequest.RequestComments,
            Employee = new EmployeeListVM
            {
                Id = leaveRequest.EmployeeId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }
        };

        return model;
    }

    private async Task UpdateAllocationDays(LeaveRequest leaveRequest, bool deductDays)
    {
        var allocation = await _leaveAllocationsService.GetCurrentAllocation
            (leaveRequest.LeaveTypeId, leaveRequest.EmployeeId);
        var numberOfDays = CalculateDays(leaveRequest.StartDate, leaveRequest.EndDate);

        if (deductDays)
        {
            allocation.Days -= numberOfDays;
        }
        else
        {
            allocation.Days += numberOfDays;
        }
        _context.Entry(allocation).State = EntityState.Modified;
    }

    private int CalculateDays(DateOnly start, DateOnly end)
    {
        return end.DayNumber - start.DayNumber;
    }
}
