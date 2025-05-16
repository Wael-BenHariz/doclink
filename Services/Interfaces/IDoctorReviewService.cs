// Services/Interfaces/IDoctorReviewService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IDoctorReviewService
    {
        Task<IEnumerable<DoctorReview>> GetByDoctorAsync(int doctorId);
        Task<IEnumerable<DoctorReview>> GetByPatientAsync(int patientId);
        Task<DoctorReview?> GetByIdAsync(int id);
        Task<DoctorReview> CreateAsync(DoctorReview review);
        Task<bool> UpdateAsync(DoctorReview review);
        Task<bool> DeleteAsync(int id);
    }
}