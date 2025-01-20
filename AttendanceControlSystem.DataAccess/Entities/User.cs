namespace AttendanceControlSystem.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
    }
}
