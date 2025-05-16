// Services/DoctorAvailabilityService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class DoctorAvailabilityService(UserDbContext context) : IDoctorAvailabilityService
    {
        public async Task<DoctorAvailability> CreateAsync(DoctorAvailability availability)
        {
            context.DoctorAvailabilities.Add(availability);
            await context.SaveChangesAsync();
            return availability;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var availability = await context.DoctorAvailabilities.FindAsync(id);
            if (availability is null)
                return false;

            context.DoctorAvailabilities.Remove(availability);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<DoctorAvailability>> GetByDoctorAsync(int doctorId)
        {
            return await context.DoctorAvailabilities
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<DoctorAvailability?> GetByIdAsync(int id)
        {
            return await context.DoctorAvailabilities.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(DoctorAvailability availability)
        {
            context.DoctorAvailabilities.Update(availability);
            return await context.SaveChangesAsync() > 0;
        }
    }
}