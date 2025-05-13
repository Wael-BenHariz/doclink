namespace DocLink.Services
{
    public interface IAppointmentService
    {
        Task<Models.Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Models.Appointment>> GetAppointmentsByPatientAsync(string patientId);
        Task<IEnumerable<Models.Appointment>> GetAppointmentsByDoctorAsync(string doctorId);
        Task AddAppointmentAsync(Models.Appointment appointment);
        Task UpdateAppointmentAsync(Models.Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
