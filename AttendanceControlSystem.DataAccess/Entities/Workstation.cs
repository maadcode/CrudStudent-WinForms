namespace AttendanceControlSystem.DataAccess.Entities
{
    public class Workstation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PcName { get; set; }
        public int? QRReaderId { get; set; }
        public int? CardReaderId { get; set; }
        public int? CameraId { get; set; }
        public int? FingerprintReaderId { get; set; }

        // Navigation Properties
        public Device QRReader { get; set; }
        public Device CardReader { get; set; }
        public Device Camera { get; set; }
        public Device FingerprintReader { get; set; }
    }
}
