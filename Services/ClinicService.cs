
using DocLink.Data;
using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class ClinicService : IClinicService
    {
        private readonly UserDbContext _context;

        public ClinicService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalClinic> GetClinicByIdAsync(int id)
        {
            return await _context.MedicalClinics.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalClinic>> GetAllClinicsAsync()
        {
            return await _context.MedicalClinics.ToListAsync();
        }

        public async Task AddClinicAsync(MedicalClinic clinic)
        {
            _context.MedicalClinics.Add(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClinicAsync(MedicalClinic clinic)
        {
            _context.MedicalClinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClinicAsync(int id)
        {
            var clinic = await _context.MedicalClinics.FindAsync(id);
            if (clinic != null)
            {
                _context.MedicalClinics.Remove(clinic);
                await _context.SaveChangesAsync();
            }
        }
    }
}
