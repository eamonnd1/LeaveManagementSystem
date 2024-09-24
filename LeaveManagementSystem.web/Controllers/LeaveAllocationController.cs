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

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
