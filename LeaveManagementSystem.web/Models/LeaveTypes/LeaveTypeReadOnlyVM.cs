﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Max leave allocation.")]
        public int NumberOfDays { get; set; }
    }    
}
