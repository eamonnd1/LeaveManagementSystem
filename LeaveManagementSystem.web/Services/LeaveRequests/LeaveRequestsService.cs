﻿using LeaveManagementSystem.web.Models.LeaveRequests;
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
        leaveRequest.LeaveRequestSatusId = (int)LeaveRequestStatusEnum.Pending;
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

    public Task<LeaveRequestReadOnlyVM> GetAllLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public async Task<List<EmployeeLeaveRequestListVM>> GetEmployeeLeaveRequests()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .Where(q => q.EmployeeId == user.Id).ToListAsync();

        var model = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
        {
            StartDate = q.StartDate,
            EndDate = q.EndDate,
            Id = q.LeaveTypeId,
            LeaveType = q.LeaveType.Name,
            LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestSatusId,
            NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
        }).ToList();

        return model;
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
