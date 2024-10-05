using LeaveManagementSystem.web.Models.LeaveRequests;
using LeaveManagementSystem.web.Services.LeaveAllocations;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.web.Services.LeaveRequests
{
    public class LeaveRequestsService(IMapper _mapper, 
        UserManager<ApplicationUser> _userManager,
        IHttpContextAccessor _httpContextAccessor) : ILeaveRequestsService
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
