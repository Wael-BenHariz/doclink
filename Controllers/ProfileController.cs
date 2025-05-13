using DocLink.DTOs;
using DocLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using DocLink.Entities;


namespace DocLink.Controllers;

[ApiController]
[Route("api/profile")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProfileController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public ProfileController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        // R�cup�rer l'ID de l'utilisateur � partir du token JWT
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Utilisateur non authentifi�" });

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound(new { message = "Utilisateur non trouv�" });

        // Construire la r�ponse en fonction du r�le de l'utilisateur
        var baseProfile = new
        {
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.Role,
            user.ProfilePhotoUrl,
            user.IsProfileComplete
        };

        // Ajouter les champs sp�cifiques aux m�decins
        if (user.Role == UserRole.Doctor)
        {
            return Ok(new
            {
                BaseProfile = baseProfile,
                DoctorDetails = new
                {
                    user.Speciality,
                    user.Description,
                    user.Diploma,
                 
                }
            });
        }

        return Ok(baseProfile);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound(new { message = "Utilisateur non trouv�" });

        // Mise � jour des champs de base
        user.FirstName = model.FirstName ?? user.FirstName;
        user.LastName = model.LastName ?? user.LastName;
        user.PhoneNumber = model.Phone ?? user.PhoneNumber;

    

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return BadRequest(new
            {
                message = "Erreur lors de la mise � jour du profil",
                errors = result.Errors.Select(e => e.Description)
            });

        return Ok(new
        {
            message = "Profil mis � jour avec succ�s",
            user = new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.PhoneNumber
            }
        });
    }

    [HttpPost("upload-photo")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        if (file == null || file.Length == 0)
            return BadRequest(new { message = "Aucun fichier t�l�charg�" });

        // V�rification de la taille du fichier (max 5MB)
        if (file.Length > 5 * 1024 * 1024)
            return BadRequest(new { message = "La taille du fichier ne doit pas d�passer 5MB" });

        try
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "profile-photos");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{userId}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { message = "Utilisateur non trouv�" });

            user.ProfilePhotoUrl = $"/Uploads/profile-photos/{uniqueFileName}";
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(new
                {
                    message = "Erreur lors de la mise � jour de la photo de profil",
                    errors = result.Errors.Select(e => e.Description)
                });

            return Ok(new
            {
                message = "Photo de profil mise � jour avec succ�s",
                photoUrl = user.ProfilePhotoUrl
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Une erreur est survenue lors du t�l�chargement du fichier",
                error = ex.Message
            });
        }
    }
}
