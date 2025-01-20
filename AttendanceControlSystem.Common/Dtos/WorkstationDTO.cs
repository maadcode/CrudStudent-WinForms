namespace AttendanceControlSystem.Common.Dtos
{
    public class WorkstationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PCName { get; set; }
        public int? QRReaderId { get; set; }
        public int? CardReaderId { get; set; }
        public int? CameraId { get; set; }
        public int? FingerprintReaderId { get; set; }
    }
}