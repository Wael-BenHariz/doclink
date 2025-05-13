using DocLink.Data;

using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly UserDbContext _context;

        public AvailabilityService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorAvailability>> GetAvailabilitiesByDoctorAsync(string doctorId)
        {
            return await _context.DoctorAvailabilities
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<DoctorAvailability> GetAvailabilityByIdAsync(int id)
        {
            return await _context.DoctorAvailabilities.FindAsync(id);
        }

        public async Task AddAvailabilityAsync(DoctorAvailability availability)
        {
            _context.DoctorAvailabilities.Add(availability);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAvailabilityAsync(DoctorAvailability availability)
        {
            _context.DoctorAvailabilities.Update(availability);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAvailabilityAsync(int id)
        {
            var availability = await _context.DoctorAvailabilities.FindAsync(id);
            if (availability != null)
            {
                _context.DoctorAvailabilities.Remove(availability);
                await _context.SaveChangesAsync();
            }
        }
    }
}
