using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.web.Controllers;
[Authorize]
public class LeaveRequestContoller : Controller
{
    // Employee View Requests
    public async Task<IActionResult> Index()
    {
        return View();
    }
    // Employee Create Requests
    public async Task<IActionResult> Create()
    {
        return View();
    }
    // Employee Create Requests
    [HttpPost]
    public async Task<IActionResult> Create(int create /* Use VM */)
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
