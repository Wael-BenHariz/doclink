// Services/Interfaces/IHealthcareServiceService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IHealthcareServiceService
    {
        Task<IEnumerable<HealthcareService>> GetByDoctorAsync(int doctorId);
        Task<HealthcareService?> GetByIdAsync(int id);
        Task<HealthcareService> CreateAsync(HealthcareService service);
        Task<bool> UpdateAsync(HealthcareService service);
        Task<bool> DeleteAsync(int id);
    }
}