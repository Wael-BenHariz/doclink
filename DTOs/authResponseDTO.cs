using DocLink.Models;

namespace DocLink.DTOs
{
    public class AuthResponseDto
    {
        public required UserAuthDto User { get; set; }
        public required string AccessToken { get; set; }
    }

    public class UserAuthDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public bool IsProfileComplete { get; set; }

        // Doctor specific fields
        public string? Speciality { get; set; }
        public string? Description { get; set; }
        public string? Diploma { get; set; }
        public int? ClinicId { get; set; }
    }
}