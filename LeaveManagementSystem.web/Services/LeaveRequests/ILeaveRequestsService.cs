using LeaveManagementSystem.web.Models.LeaveRequests;

namespace LeaveManagementSystem.web.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreatLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequest();
        Task<LeaveRequestListVM> GetAllLeaveRequest();
        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);
    }
}