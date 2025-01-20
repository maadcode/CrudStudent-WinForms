using AttendanceControlSystem.Common.Enums;

namespace AttendanceControlSystem.Common.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}