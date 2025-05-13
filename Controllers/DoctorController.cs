using DocLink.Entities;
using DocLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Controllers

{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public DoctorController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/doctors
        [HttpGet]
        [AllowAnonymous] // Ou [Authorize] si nécessaire
        public async Task<IActionResult> GetAvailableDoctors()
        {
            var doctors = await _userManager.Users
                .Where(u => u.Role.ToString() == UserRole.Doctor.ToString()/* && u.IsProfileComplete*/)
                .Select(u => new
                {
                    id = u.Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    email = u.Email,
                    Role = UserRole.Doctor.ToString(),

                    profilePhotoUrl = u.ProfilePhotoUrl,
                    speciality = u.Speciality,
                    description = u.Description,
                    diploma = u.Diploma,
                    phone = u.PhoneNumber,
               
                })
                .ToListAsync();

            return Ok(doctors);
        }

        // GET: api/doctors/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { message = "Doctor ID is required" });

            var doctor = await _userManager.Users
                .Where(u => u.Id.Equals(id)  && u.Role == UserRole.Doctor && u.IsProfileComplete)
                .Select(u => new
                {
                    id = u.Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    email = u.Email,
                    Role = UserRole.Doctor.ToString(),
                    profilePhotoUrl = u.ProfilePhotoUrl,
                    speciality = u.Speciality,
                    description = u.Description,
                    diploma = u.Diploma,
                    phone = u.PhoneNumber,
                
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

            var doctors = await _userManager.Users
                .Where(u => u.Role == UserRole.Doctor && u.IsProfileComplete && u.Speciality.ToLower().Contains(speciality.ToLower()))
                .Select(u => new
                {
                    id = u.Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    email = u.Email,
                    profilePhotoUrl = u.ProfilePhotoUrl,
                    speciality = u.Speciality,
                    description = u.Description,
                    diploma = u.Diploma,
                    phone = u.PhoneNumber,
           
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

            var doctors = await _userManager.Users
                .Where(u => u.Role == UserRole.Doctor && u.IsProfileComplete &&
                            (u.FirstName.ToLower().Contains(name.ToLower()) || u.LastName.ToLower().Contains(name.ToLower())))
                .Select(u => new
                {
                    id = u.Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    email = u.Email,
                    profilePhotoUrl = u.ProfilePhotoUrl,
                    speciality = u.Speciality,
                    description = u.Description,
                    diploma = u.Diploma,
                    phone = u.PhoneNumber,
                  
                })
                .ToListAsync();

            return Ok(doctors);
        }

    }
}
