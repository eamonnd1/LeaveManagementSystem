
namespace LeaveManagementSystem.web.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
        Task<List<LeaveAllocation>> GetAllocations();
        Task<EmployeeAllocationVM> GetEmployeeAllocations();
    }
}
