using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IClinicService
    {

        Task<MedicalClinic> GetClinicByIdAsync(int id);
        Task<IEnumerable<MedicalClinic>> GetAllClinicsAsync();
        Task AddClinicAsync(MedicalClinic clinic);
        Task UpdateClinicAsync(MedicalClinic clinic);
        Task DeleteClinicAsync(int id);
    }
}
