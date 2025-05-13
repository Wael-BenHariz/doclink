using DocLink.Data;

using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class HealthcareServiceService : IHealthcareServiceService
    {
        private readonly UserDbContext _context;

        public HealthcareServiceService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HealthcareService>> GetServicesByDoctorAsync(string doctorId)
        {
            return await _context.HealthcareServices
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<HealthcareService> GetServiceByIdAsync(int id)
        {
            return await _context.HealthcareServices.FindAsync(id);
        }

        public async Task AddServiceAsync(HealthcareService service)
        {
            _context.HealthcareServices.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(HealthcareService service)
        {
            _context.HealthcareServices.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.HealthcareServices.FindAsync(id);
            if (service != null)
            {
                _context.HealthcareServices.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
