using System;

namespace AttendanceControlSystem.DataAccess.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        // Navigation Property
        public Department Department { get; set; }
    }
}
