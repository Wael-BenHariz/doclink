using DocLink.Data;
using DocLink.DTOs;
using DocLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly UserDbContext _context;

        public DoctorController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/doctors
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAvailableDoctors()
        {
            var doctors = await _context.Users
                .Where(u => u.Role == UserRole.Doctor && u.IsProfileComplete)
                .Select(u => new DoctorDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    ProfilePhotoUrl = u.ProfilePhotoUrl,
                    Speciality = u.Speciality,
                    Description = u.Description,
                    Diploma = u.Diploma,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            return Ok(doctors);
        }

        // GET: api/doctors/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _context.Users
                .Where(u => u.Id == id && u.Role == UserRole.Doctor && u.IsProfileComplete)
                .Select(u => new DoctorDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    ProfilePhotoUrl = u.ProfilePhotoUrl,
                    Speciality = u.Speciality,
                    Description = u.Description,
                    Diploma = u.Diploma,
                    PhoneNumber = u.PhoneNumber,
                })
                .FirstOrDefaultAsync();

            if (doctor == null)
                return NotFound(new { message = "Doctor not found or profile not complete" });

            return Ok(doctor);
        }

        // GET: api/doctors/by-speciality?speciality=Cardiologie
        [HttpGet("by-speciality")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorsBySpeciality([FromQuery] string speciality)
        {
            if (string.IsNullOrEmpty(speciality))
                return BadRequest(new { message = "Speciality is required" });

            var doctors = await _context.Users
                .Where(u => u.Role == UserRole.Doctor &&
                          u.IsProfileComplete &&
                          u.Speciality.ToLower().Contains(speciality.ToLower()))
                .Select(u => new DoctorDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ProfilePhotoUrl = u.ProfilePhotoUrl,
                    Speciality = u.Speciality,
                    Description = u.Description,
                    Diploma = u.Diploma,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            return Ok(doctors);
        }

        // GET: api/doctors/by-name?name=Ali
        [HttpGet("by-name")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorsByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest(new { message = "Name is required" });

            var doctors = await _context.Users
                .Where(u => u.Role == UserRole.Doctor &&
                          u.IsProfileComplete &&
                          (u.FirstName.ToLower().Contains(name.ToLower()) ||
                           u.LastName.ToLower().Contains(name.ToLower())))
                .Select(u => new DoctorDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ProfilePhotoUrl = u.ProfilePhotoUrl,
                    Speciality = u.Speciality,
                    Description = u.Description,
                    Diploma = u.Diploma,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            return Ok(doctors);
        }
    }
}