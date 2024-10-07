﻿using LeaveManagementSystem.web.Services.LeaveRequests;
using LeaveManagementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.web.Controllers
{
    [Authorize]
    public class LeaveRequestsController(ILeaveTypesService _leaveTypesService, ILeaveRequestsService _leaveRequestsService) : Controller
    {

        // Employee View Requests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestsService.GetEmployeeLeaveRequests();
            return View(model);
        }

        // Employee Create Requests (GET)
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

        // Employee Create Requests (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            // Validate - Days dont exceed allocation
            if(await _leaveRequestsService.RequestDatesExceedAllocation(model))
            {
                ModelState.AddModelError(string.Empty, "Leave requested exceeds allocation.");
                ModelState.AddModelError(nameof(model.EndDate), "The number of days is invalid.");
            }

            if (ModelState.IsValid)
            {
                await _leaveRequestsService.CreatLeaveRequest(model);
                return RedirectToAction(nameof(Index));
            }
            var leaveTypes = await _leaveTypesService.GetAll();
            model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
            return View(model);
        }

        // Employee Cancel Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int leaveRequestId)
        {
            return View();
        }

        // Admin/Supervisor Review Requests (GET)
        public async Task<IActionResult> ListRequests()
        {
            return View();
        }

        // Admin/Supervisor Review Single Request (GET)
        public async Task<IActionResult> Review(int leaveRequestId)
        {
            return View();
        }

        // Admin/Supervisor Review Single Request (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(ReviewLeaveRequestVM model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(ListRequests));
            }

            return View(model);
        }
    }
}
