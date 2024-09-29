namespace LeaveManagementSystem.web.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate {  get; set; }
    }
}