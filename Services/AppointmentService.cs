// Services/AppointmentService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class AppointmentService(UserDbContext context) : IAppointmentService
    {
        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment is null)
                return false;

            context.Appointments.Remove(appointment);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorAsync(int doctorId)
        {
            return await context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientAsync(int patientId)
        {
            return await context.Appointments
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await context.Appointments.FindAsync(id);
        }

        public async Task<bool> UpdateStatusAsync(int id, AppointmentStatus status)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment is null)
                return false;

            appointment.Status = status;
            return await context.SaveChangesAsync() > 0;
        }
    }
}