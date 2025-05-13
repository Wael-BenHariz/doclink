using DocLink.Models;

namespace DocLink.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<DoctorReview>> GetReviewsForDoctorAsync(string doctorId);
        Task<IEnumerable<DoctorReview>> GetReviewsByPatientAsync(string patientId);
        Task<DoctorReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(DoctorReview review);
        Task UpdateReviewAsync(DoctorReview review);
        Task DeleteReviewAsync(int id);
    }
}
