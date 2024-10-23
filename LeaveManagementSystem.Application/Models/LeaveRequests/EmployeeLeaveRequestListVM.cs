namespace LeaveManagementSystem.Application.Models.LeaveRequests;

public class EmployeeLeaveRequestListVM
{
    [Display(Name = "Total")]
    public int TotalRequests { get; set; }

    [Display(Name = "Approved")]
    public int ApprovedRequests { get; set; }

    [Display(Name = "Pending")]
    public int PendingRequests { get; set; }

    [Display(Name = "Declined")]
    public int DeclinedRequests { get; set; }

    public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = [];
}