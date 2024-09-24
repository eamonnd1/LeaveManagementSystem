using LeaveManagementSystem.web.Services.LeaveAllocations;

namespace LeaveManagementSystem.web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService) : Controller
{
    public async Task<IActionResult> Details()
    {
        var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations();
        return View(employeeVM);
    }
}
