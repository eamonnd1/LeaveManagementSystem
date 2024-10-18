namespace LeaveManagementSystem.Application.Models.LeaveTypes;

public class LeaveTypeEditVM : BaseLeaveTypeVM
{
    [Required]
    [Length(4, 150, ErrorMessage = "Enter a value between 4 and 150 chatacters")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 90)]
    [Display(Name = "Max leave allocation.")]
    public int NumberOfDays { get; set; }
}
