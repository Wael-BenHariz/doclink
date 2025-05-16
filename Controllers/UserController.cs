using DocLink.DTOs;
using DocLink.Models;
using DocLink.Services;
using DocLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await userService.GetByIdAsync(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("doctors")]
        public async Task<ActionResult<IEnumerable<User>>> GetDoctors()
        {
            var doctors = await userService.GetDoctorsAsync();
            return Ok(doctors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto userUpdate)
        {
            if (id != userUpdate.Id)
                return BadRequest();

            var result = await userService.UpdateAsync(userUpdate);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/complete-profile")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CompleteProfile(int id, DoctorProfileDto profile)
        {
            if (id != profile.Id)
                return BadRequest();

            var result = await userService.CompleteDoctorProfileAsync(profile);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}