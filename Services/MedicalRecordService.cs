using DocLink.Data;
using DocLink.Models;
using DocLink.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly UserDbContext _context;

        public MedicalRecordService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientMedicalRecord>> GetRecordsByPatientAsync(string patientId)
        {
            return await _context.PatientMedicalRecords
                .Where(r => r.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<PatientMedicalRecord> GetRecordByIdAsync(int id)
        {
            return await _context.PatientMedicalRecords.FindAsync(id);
        }

        public async Task AddMedicalRecordAsync(PatientMedicalRecord record)
        {
            _context.PatientMedicalRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedicalRecordAsync(PatientMedicalRecord record)
        {
            _context.PatientMedicalRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            var record = await _context.PatientMedicalRecords.FindAsync(id);
            if (record != null)
            {
                _context.PatientMedicalRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}