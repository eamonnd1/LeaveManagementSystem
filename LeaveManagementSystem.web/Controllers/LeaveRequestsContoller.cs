﻿using LeaveManagementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace LeaveManagementSystem.web.Controllers
{
    [Authorize]
    public class LeaveRequestsController(ILeaveTypesService _leaveTypesService) : Controller
    {

        // Employee View Requests
        public async Task<IActionResult> Index()
        {
            return View();
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
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            return View(model);
        }

        // Employee Cancel Request
        [HttpPost]
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
