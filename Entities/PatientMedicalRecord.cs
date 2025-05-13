using DocLink.Entities;

namespace DocLink.Models
{
    public class PatientMedicalRecord
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public User Patient { get; set; }

        public DateTime CreatedAt { get; set; }
        public string RecordDetails { get; set; }
    }
}
