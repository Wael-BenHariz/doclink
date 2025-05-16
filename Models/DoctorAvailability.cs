namespace DocLink.Models
{
    public class DoctorAvailability
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public User Doctor { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
