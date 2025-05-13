using DocLink.Models;

namespace DocLink.Services
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<PatientMedicalRecord>> GetRecordsByPatientAsync(string patientId);
        Task<PatientMedicalRecord> GetRecordByIdAsync(int id);
        Task AddMedicalRecordAsync(PatientMedicalRecord record);
        Task UpdateMedicalRecordAsync(PatientMedicalRecord record);
        Task DeleteMedicalRecordAsync(int id);
    }
}
