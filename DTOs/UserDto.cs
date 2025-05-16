using System.Text.Json.Serialization;
using DocLink.Models;

namespace DocLink.DTOs
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; } = UserRole.Patient; 

    }
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

    public class DoctorProfileDto
    {
        public int Id { get; set; }
        public string Speciality { get; set; }
        public string Description { get; set; }
        public string Diploma { get; set; }
        public string ProfilePhotoUrl { get; set; }
    }
}
