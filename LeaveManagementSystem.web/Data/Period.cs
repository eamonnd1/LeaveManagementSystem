﻿namespace LeaveManagementSystem.web.Data
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
