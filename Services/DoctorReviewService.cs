// Services/DoctorReviewService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class DoctorReviewService(UserDbContext context) : IDoctorReviewService
    {
        public async Task<DoctorReview> CreateAsync(DoctorReview review)
        {
            context.DoctorReviews.Add(review);
            await context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await context.DoctorReviews.FindAsync(id);
            if (review is null)
                return false;

            context.DoctorReviews.Remove(review);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<DoctorReview>> GetByDoctorAsync(int doctorId)
        {
            return await context.DoctorReviews
                .Where(r => r.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorReview>> GetByPatientAsync(int patientId)
        {
            return await context.DoctorReviews
                .Where(r => r.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<DoctorReview?> GetByIdAsync(int id)
        {
            return await context.DoctorReviews.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(DoctorReview review)
        {
            context.DoctorReviews.Update(review);
            return await context.SaveChangesAsync() > 0;
        }
    }
}