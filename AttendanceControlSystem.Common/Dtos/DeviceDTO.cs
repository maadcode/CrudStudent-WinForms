using AttendanceControlSystem.Common.Enums;

namespace AttendanceControlSystem.Common.Dtos
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeDevice Type { get; set; }
    }
}