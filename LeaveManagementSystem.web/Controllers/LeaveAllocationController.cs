using LeaveManagementSystem.web.Services.LeaveAllocations;

namespace LeaveManagementSystem.web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var leaveAllocations = await _leaveAllocationsService.GetAllocations();
        return View();
    }
}
