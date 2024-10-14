using LeaveManagementSystem.web.Services.Periods;
using LeaveManagementSystem.web.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Services.LeaveAllocations;

public class LeaveAllocationsService(ApplicationDbContext _context,
    IUserService _UserService,
    IMapper _mapper, IPeriodsService _periodsService) : ILeaveAllocationsService
{
    public async Task AllocateLeave(string employeeId)
    {
        var leaveTypes = await _context.LeaveTypes
            .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
            .ToListAsync();

        DateTime currentDate = DateTime.Now;
        var period = await _periodsService.GetCurrentPeriod();
        var monthsRemaining = period.EndDate.Month - currentDate.Month;

        foreach (var leaveType in leaveTypes)
        {
            var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
                LeaveTypeId = leaveType.Id,
                PeriodId = period.Id,
                Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
            };

            _context.Add(leaveAllocation);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
    {
        var user = string.IsNullOrEmpty(userId)
            ? await _UserService.GetLoggedInUser()
            : await _UserService.GetUserById(userId);

        var allocations = await GetAllocations(user.Id);
        var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
        var leaveTypesCount = await _context.LeaveTypes.CountAsync();

        var employeeVm = new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationVmList,
            IsCompletedAllocation = leaveTypesCount == allocations.Count
        };

        return employeeVm;
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _UserService.GetEmployees();
        var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users);
    
        return employees;
    }

    public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
    {
        var allocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == allocationId);

        var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

        return model;
    }

    public async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
    {
        var allocation = await GetEmployeeAllocation(allocationEditVM.Id);
        await _context.LeaveAllocations
            .Where(q => q.Id == allocationEditVM.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));
    }

    public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
    {
        var period = await _periodsService.GetCurrentPeriod();
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == leaveTypeId
            && q.EmployeeId == employeeId
            && q.PeriodId == period.Id);
        return allocation;
    }

    private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
    {
        DateTime currentDate = DateTime.Now;
        var leaveAllocations = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Period)
            .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year)
            .ToListAsync();

        return leaveAllocations;
    }

    private async Task<bool> AllocationExists(string? userId, int periodId, int LeaveTypeId)
    {
        var exists = await _context.LeaveAllocations.AnyAsync(q => 
        q.EmployeeId == userId
        && q.LeaveTypeId == LeaveTypeId
        && q.PeriodId == periodId);

        return exists;
    }


}
