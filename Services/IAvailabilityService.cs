using DocLink.Models;

namespace DocLink.Services
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<DoctorAvailability>> GetAvailabilitiesByDoctorAsync(string doctorId);
        Task<DoctorAvailability> GetAvailabilityByIdAsync(int id);
        Task AddAvailabilityAsync(DoctorAvailability availability);
        Task UpdateAvailabilityAsync(DoctorAvailability availability);
        Task DeleteAvailabilityAsync(int id);
    }
}
