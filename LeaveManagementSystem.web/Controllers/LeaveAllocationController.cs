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

    [Authorize(Roles =Roles.Administrator)]
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
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocationEditVM)
    {
        await _leaveAllocationsService.EditAllocation(allocationEditVM);
        return RedirectToAction(nameof(Details), new { userId = allocationEditVM.Employee.Id });
    }

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
