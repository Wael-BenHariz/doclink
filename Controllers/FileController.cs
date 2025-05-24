using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpPost("upload-profile-photo")]
    public async Task<IActionResult> UploadProfilePhoto(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/profile_photos");
        Directory.CreateDirectory(uploadsFolder);

        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        string fullUrl = $"http://localhost:5190/uploads/profile_photos/{uniqueFileName}";
        return Ok(new { imageUrl = fullUrl });
    }
}
