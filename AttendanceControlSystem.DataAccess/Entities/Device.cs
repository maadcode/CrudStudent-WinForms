using System.Collections.Generic;

namespace AttendanceControlSystem.DataAccess.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }

        // Navigation Property
        public ICollection<Workstation> Workstations { get; set; }
    }
}
