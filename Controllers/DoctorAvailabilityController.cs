using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DoctorAvailabilityController(IDoctorAvailabilityService availabilityService) : ControllerBase
    {
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<DoctorAvailability>>> GetByDoctor(int doctorId)
        {
            var availabilities = await availabilityService.GetByDoctorAsync(doctorId);
            return Ok(availabilities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorAvailability>> GetById(int id)
        {
            var availability = await availabilityService.GetByIdAsync(id);
            if (availability is null)
                return NotFound();

            return Ok(availability);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorAvailability>> Create(DoctorAvailability availability)
        {
            var createdAvailability = await availabilityService.CreateAsync(availability);
            return CreatedAtAction(nameof(GetById), new { id = createdAvailability.Id }, createdAvailability);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorAvailability availability)
        {
            if (id != availability.Id)
                return BadRequest();

            var result = await availabilityService.UpdateAsync(availability);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await availabilityService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}