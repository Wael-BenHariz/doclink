using Microsoft.AspNetCore.Mvc;
using DocLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DocLink.Entities;

namespace DocLink.Controllers { 
    [Route("api/patient")]
    [ApiController]
public class PatientController : ControllerBase
    {
    private readonly UserManager<User> _userManager;

    public PatientController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

        /*
    [AllowAnonymous]
    [HttpGet]

    public async Task<IActionResult> GetAvailablePatients()
    {
        var patients = await _userManager.Users
            .Where(u => u.Role.ToString() == UserRole.Patient.ToString() )
            .Select(u => new
            {
                id = u.Id,
                firstName = u.FirstName,
                lastName = u.LastName,
                email = u.Email,
                Role = UserRole.Patient.ToString(),

              
            })
            .ToListAsync();

        return Ok(patients);
    }*/



        [HttpGet("patients")]
        public async Task<IActionResult> GetAvailablePatients()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.FindByIdAsync(userId);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            var patients = await _userManager.Users
                .Where(u => u.Role == UserRole.Patient)
                .ToListAsync();

            var result = patients.Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                RequestedBy = new { currentUser.Id, currentUser.Email }
            });

            return Ok(result);
        }


    }
}
