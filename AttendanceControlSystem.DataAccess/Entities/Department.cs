using System.Collections.Generic;

namespace AttendanceControlSystem.DataAccess.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<User> Users { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
