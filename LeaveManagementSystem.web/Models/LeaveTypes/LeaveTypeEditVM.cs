using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.web.Models.LeaveTypes
{
    public class LeaveTypeEditVM
    {
        public int Id { get; set; }

        [Required]
        [Length(4, 150, ErrorMessage = "Enter a value between 4 and 150 chatacters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 90)]
        public int NumberOfDays { get; set; }
    }
}
