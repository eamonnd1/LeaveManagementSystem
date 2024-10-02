using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.web.Models.LeaveRequests;

public class LeaveRequestCreateVM
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string? RequestComments { get; set; }

    public SelectList LeaveTypes { get; set; }
}