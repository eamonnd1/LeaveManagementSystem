namespace LeaveManagementSystem.web.Models.LeaveRequests;

public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
{
    public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
}