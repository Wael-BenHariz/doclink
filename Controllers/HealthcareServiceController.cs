using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class HealthcareServiceController(IHealthcareServiceService healthcareService) : ControllerBase
    {
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<HealthcareService>>> GetByDoctor(int doctorId)
        {
            var services = await healthcareService.GetByDoctorAsync(doctorId);
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthcareService>> GetById(int id)
        {
            var service = await healthcareService.GetByIdAsync(id);
            if (service is null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<HealthcareService>> Create(HealthcareService service)
        {
            var createdService = await healthcareService.CreateAsync(service);
            return CreatedAtAction(nameof(GetById), new { id = createdService.Id }, createdService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HealthcareService service)
        {
            if (id != service.Id)
                return BadRequest();

            var result = await healthcareService.UpdateAsync(service);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await healthcareService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}