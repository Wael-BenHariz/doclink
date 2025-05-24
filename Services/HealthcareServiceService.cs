// Services/HealthcareServiceService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class HealthcareServiceService(UserDbContext context) : IHealthcareServiceService
    {
        public async Task<HealthcareService> CreateAsync(HealthcareService service)
        {

            
            context.HealthcareServices.Add(service);
            await context.SaveChangesAsync();
            return service;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var service = await context.HealthcareServices.FindAsync(id);
            if (service is null)
                return false;

            context.HealthcareServices.Remove(service);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<HealthcareService>> GetAll()
        {
            return await context.HealthcareServices.ToListAsync();
        }

        public async Task<IEnumerable<HealthcareService>> GetByDoctorAsync(int doctorId)
        {
            return await context.HealthcareServices
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<HealthcareService?> GetByIdAsync(int id)
        {
            return await context.HealthcareServices.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(HealthcareService service)
        {
            context.HealthcareServices.Update(service);
            return await context.SaveChangesAsync() > 0;
        }
    }
}