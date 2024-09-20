﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.web.Data;

public class LeaveType : BaseEntity
{
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; }
    public int NumberOfDays { get; set; }
}
