using DocLink.Models;

namespace DocLink.Services
{
    public interface IHealthcareServiceService
    {
        Task<IEnumerable<HealthcareService>> GetServicesByDoctorAsync(string doctorId);
        Task<HealthcareService> GetServiceByIdAsync(int id);
        Task AddServiceAsync(HealthcareService service);
        Task UpdateServiceAsync(HealthcareService service);
        Task DeleteServiceAsync(int id);
    }
}
