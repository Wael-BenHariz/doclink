// Services/Interfaces/IMedicalClinicService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IMedicalClinicService
    {
        Task<IEnumerable<MedicalClinic>> GetAllAsync();
        Task<MedicalClinic?> GetByIdAsync(int id);
        Task<MedicalClinic> CreateAsync(MedicalClinic clinic);
        Task<bool> UpdateAsync(MedicalClinic clinic);
        Task<bool> DeleteAsync(int id);
    }
}