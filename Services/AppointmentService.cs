using DocLink.Data;
using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly UserDbContext _context;

        public AppointmentService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Models.Appointment>> GetAppointmentsByPatientAsync(string patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId.Equals(patientId)  )
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Appointment>> GetAppointmentsByDoctorAsync(string doctorId)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId.Equals(doctorId))
                .ToListAsync();
        }

        public async Task AddAppointmentAsync(Models.Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Models.Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<Models.Appointment>> IAppointmentService.GetAppointmentsByPatientAsync(string patientId)
        {
            throw new NotImplementedException();
        }

    }
}
