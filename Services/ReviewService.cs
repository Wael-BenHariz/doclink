using DocLink.Data;
using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class ReviewService : IReviewService
    {
        private readonly UserDbContext _context;

        public ReviewService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorReview>> GetReviewsForDoctorAsync(string doctorId)
        {
            return await _context.DoctorReviews
                .Where(r => r.DoctorId.Equals(doctorId) )
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorReview>> GetReviewsByPatientAsync(string patientId)
        {
            return await _context.DoctorReviews
                .Where(r => r.PatientId.Equals(patientId))
                .ToListAsync();
        }

        public async Task<DoctorReview> GetReviewByIdAsync(int id)
        {
            return await _context.DoctorReviews.FindAsync(id);
        }

        public async Task AddReviewAsync(DoctorReview review)
        {
            _context.DoctorReviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(DoctorReview review)
        {
            _context.DoctorReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.DoctorReviews.FindAsync(id);
            if (review != null)
            {
                _context.DoctorReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
