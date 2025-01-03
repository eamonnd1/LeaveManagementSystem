﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequests;

public class LeaveRequestCreateVM : IValidatableObject
{
    [Required]
    [DisplayName("Start Date")]
    public DateOnly StartDate { get; set; }
    [Required]
    [DisplayName("End Date")]
    public DateOnly EndDate { get; set; }
    [Required]
    [DisplayName("Desired Leave Type")]
    public int LeaveTypeId { get; set; }
    [DisplayName("Additional Information")]
    [StringLength(250)]
    public string? RequestComments { get; set; }

    public SelectList? LeaveTypes { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate >= EndDate)
        {
            yield return new ValidationResult("End date must be later than start date",
            [nameof(StartDate), nameof(EndDate)]);
        }
    }
}