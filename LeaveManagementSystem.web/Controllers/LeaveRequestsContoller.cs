using LeaveManagementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.web.Controllers;
[Authorize]


public class LeaveRequestsContoller(ILeaveTypesService _leaveTypesService) : Controller
{
    // Employee View Requests
    public async Task<IActionResult> Index()
    {
        return View();
    }
    // Employee Create Requests
    public async Task<IActionResult> Create()
    {
        var leaveTypes = await _leaveTypesService.GetAll();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name");
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = leaveTypesList
        };
        return View(model);
    }
    // Employee Create Requests
    [HttpPost]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        return View();
    }
    // Employee Create Requests
    [HttpPost]
    public async Task<IActionResult> Cancel(int LeaveRequestId)
    {
        return View();
    }

    // Admin/Supervisor Review Request
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }
    // Admin/Supervisor Review Requests
    public async Task<IActionResult> Review(int LeaveRequestId)
    {
        return View();
    }
    // Admin/Supervisor Review Requests
    [HttpPost]
    public async Task<IActionResult> Review(/* Use VM */)
    {
        return View();
    }
}
