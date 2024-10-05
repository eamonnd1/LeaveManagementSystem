using LeaveManagementSystem.web.Models.LeaveRequests;
using LeaveManagementSystem.web.Services.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Services.LeaveRequests;

public class LeaveRequestsService(IMapper _mapper, 
    UserManager<ApplicationUser> _userManager,
    IHttpContextAccessor _httpContextAccessor,
    ApplicationDbContext _context) : ILeaveRequestsService
{
    public Task CancelLeaveRequest(int leaveRequestId)
    {
        throw new NotImplementedException();
    }

    public async Task CreatLeaveRequest(LeaveRequestCreateVM model)
    {
        // Map Data to leave requset data model
        var leaveRequest = _mapper.Map<LeaveRequest>(model);
        // Get logged in employee ID
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        leaveRequest.EmployeeId = user.Id;
        // Set LeaveRequestStatusId to pending
        leaveRequest.LeaveRequestSatusId = (int)LeaveRequestStatus.Pending;
        // Save leave request
        _context.Add(leaveRequest);
        
        // Deduct allaction based on requested days
        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocationToDeduct = await _context.LeaveAllocations.
            FirstOrDefaultAsync(q => q.LeaveTypeId == model.LeaveTypeId &&
            q.EmployeeId == user.Id);

        allocationToDeduct.Days -= numberOfDays;
        await _context.SaveChangesAsync();
    }

    public Task<LeaveRequestListVM> GetAllLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context.LeaveAllocations.
            FirstOrDefaultAsync(q => q.LeaveTypeId == model.LeaveTypeId &&
            q.EmployeeId == user.Id);
        
        return allocation.Days < numberOfDays;
    }

    public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
    {
        throw new NotImplementedException();
    }
}
