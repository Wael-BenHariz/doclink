// Models/DTOs/AppointmentDto.cs
using System;

namespace DocLink.DTOs
{
    public class AppointmentDto
    {
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
    }

    public class AppointmentUpdateDto : AppointmentDto
    {
        public int Id { get; set; }
    }
}