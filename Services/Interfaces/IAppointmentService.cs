// Services/Interfaces/IAppointmentService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetByDoctorAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetByPatientAsync(int patientId);
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<bool> UpdateStatusAsync(int id, AppointmentStatus status);
        Task<bool> DeleteAsync(int id);
    }
}