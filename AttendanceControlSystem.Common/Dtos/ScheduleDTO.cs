namespace AttendanceControlSystem.Common.Dtos
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}