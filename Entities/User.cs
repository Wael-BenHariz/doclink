using DocLink.Models;

namespace DocLink.Entities
{
    public enum UserRole
    {
        Patient,
        Doctor,
        Admin
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Patient;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string? Speciality { get; set; }
        public string? Description { get; set; }

        public string? Diploma { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        public bool IsProfileComplete { get; set; } = false;

        public int? ClinicId { get; set; }
        public MedicalClinic? Clinic { get; set; }

        public ICollection<DoctorAvailability>? Availabilities { get; set; }
        public ICollection<DoctorReview>? ReviewsReceived { get; set; }  // As doctor
        public ICollection<DoctorReview>? ReviewsWritten { get; set; }   // As patient
        public ICollection<HealthcareService>? ServicesOffered { get; set; }
        public ICollection<Appointment>? DoctorAppointments { get; set; }
        public ICollection<Appointment>? PatientAppointments { get; set; }
        public ICollection<PaymentTransaction>? PaymentTransactions { get; set; }
    }
}
