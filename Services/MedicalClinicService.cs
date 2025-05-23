// Services/MedicalClinicService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class MedicalClinicService(UserDbContext context) : IMedicalClinicService
    {
        public async Task<MedicalClinic> CreateAsync(MedicalClinic clinic)
        {
            context.MedicalClinics.Add(clinic);
            await context.SaveChangesAsync();
            return clinic;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var clinic = await context.MedicalClinics.FindAsync(id);
            if (clinic is null)
                return false;

            context.MedicalClinics.Remove(clinic);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<MedicalClinic>> GetAllAsync()
        {
            return await context.MedicalClinics.ToListAsync();
        }

        public async Task<MedicalClinic?> GetByIdAsync(int id)
        {
            return await context.MedicalClinics.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(MedicalClinic clinic)
        {

            var existingEntity = context.MedicalClinics.Local.FirstOrDefault(e => e.Id == clinic.Id);
            if (existingEntity != null)
            {
                context.Entry(existingEntity).State = EntityState.Detached;
            }
            context.MedicalClinics.Update(clinic);
            return await context.SaveChangesAsync() > 0;
        }
    }
}