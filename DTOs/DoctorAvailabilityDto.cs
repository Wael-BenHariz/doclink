// Models/DTOs/DoctorAvailabilityDto.cs
using System;

namespace DocLink.DTOs
{
    public class DoctorAvailabilityDto
    {
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek Day { get; set; }
    }

    public class DoctorAvailabilityUpdateDto : DoctorAvailabilityDto
    {
        public int Id { get; set; }
    }
}