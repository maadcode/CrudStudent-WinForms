using AttendanceControlSystem.Common.Enums;
using System;

namespace AttendanceControlSystem.Common.Dtos
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}