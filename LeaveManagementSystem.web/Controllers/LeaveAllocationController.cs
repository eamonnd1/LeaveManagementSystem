using LeaveManagementSystem.web.Services.LeaveAllocations;

namespace LeaveManagementSystem.web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService) : Controller
{
    [Authorize(Roles = Roles.Administrator)]
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

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
