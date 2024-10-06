using LeaveManagementSystem.web.Models.LeaveRequests;

namespace LeaveManagementSystem.web.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreatLeaveRequest(LeaveRequestCreateVM model);
        Task<LeaveRequestReadOnlyVM> GetAllLeaveRequests();
        Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
    }
}