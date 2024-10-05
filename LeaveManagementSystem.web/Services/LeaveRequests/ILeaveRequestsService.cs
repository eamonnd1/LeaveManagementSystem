﻿using LeaveManagementSystem.web.Models.LeaveRequests;

namespace LeaveManagementSystem.web.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreatLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequests();
        Task<LeaveRequestListVM> GetAllLeaveRequests();
        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
    }
}