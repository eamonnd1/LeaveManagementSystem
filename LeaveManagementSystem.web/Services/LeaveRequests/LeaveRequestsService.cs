using LeaveManagementSystem.web.Models.LeaveRequests;
using LeaveManagementSystem.web.Services.LeaveAllocations;

namespace LeaveManagementSystem.web.Services.LeaveRequests
{
    public class LeaveRequestsService : ILeaveRequestsService
    {
        public Task CancelLeaveRequest(int leaveRequestId)
        {
            throw new NotImplementedException();
        }

        public Task CreatLeaveRequest(LeaveRequestCreateVM model)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestListVM> GetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
