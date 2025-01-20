using System;

namespace AttendanceControlSystem.DataAccess.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public bool IsLate { get; set; }
        public bool IsAbsent { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}
