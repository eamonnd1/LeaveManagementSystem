﻿using LeaveManagementSystem.Application.Models.LeaveAllocations;
using LeaveManagementSystem.Application.Services.LeaveAllocations;
using LeaveManagementSystem.Application.Services.LeaveTypes;

namespace LeaveManagementSystem.web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService, ILeaveTypesService _leaveTypesService) : Controller
{
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> Index()
    {
        var employees = await _leaveAllocationsService.GetEmployees();
        return View(employees);
    }
    [Authorize(Roles = Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AllocateLeave(string? Id)
    {
        await _leaveAllocationsService.AllocateLeave(Id);
        return RedirectToAction(nameof(Details), new { userId = Id });
    }

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> EditAllocation(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var allocation = await _leaveAllocationsService.GetEmployeeAllocation(id.Value);
        if (allocation == null)
        {
            return NotFound();
        }
        return View(allocation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocation)
    {
        if (await _leaveTypesService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
        {
            ModelState.AddModelError("Days", "The allocation exceeds the maximum leave type value");
        }

        if (ModelState.IsValid)
        {
            await _leaveAllocationsService.EditAllocation(allocation);
            return RedirectToAction(nameof(Details), new { userId = allocation.Employee.Id });
        }

        var days = allocation.Days;
        allocation = await _leaveAllocationsService.GetEmployeeAllocation(allocation.Id);
        allocation.Days = days;
        return View(allocation);
    }

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
