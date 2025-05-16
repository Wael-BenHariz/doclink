// Services/Interfaces/IDoctorAvailabilityService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IDoctorAvailabilityService
    {
        Task<IEnumerable<DoctorAvailability>> GetByDoctorAsync(int doctorId);
        Task<DoctorAvailability?> GetByIdAsync(int id);
        Task<DoctorAvailability> CreateAsync(DoctorAvailability availability);
        Task<bool> UpdateAsync(DoctorAvailability availability);
        Task<bool> DeleteAsync(int id);
    }
}