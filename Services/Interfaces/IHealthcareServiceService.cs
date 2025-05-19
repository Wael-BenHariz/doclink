// Services/Interfaces/IHealthcareServiceService.cs
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IHealthcareServiceService
    {
        Task<IEnumerable<HealthcareService>> GetByDoctorAsync(int doctorId);
        Task<HealthcareService?> GetByIdAsync(int id);
        Task<ICollection<HealthcareService>> GetAll();
        Task<HealthcareService> CreateAsync(HealthcareService service);
        Task<bool> UpdateAsync(HealthcareService service);
        Task<bool> DeleteAsync(int id);

    }
}