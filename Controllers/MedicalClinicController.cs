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
    public class MedicalClinicController(IMedicalClinicService clinicService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalClinic>>> GetAll()
        {
            var clinics = await clinicService.GetAllAsync();
            return Ok(clinics);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalClinic>> GetById(int id)
        {
            var clinic = await clinicService.GetByIdAsync(id);
            if (clinic is null)
                return NotFound();

            return Ok(clinic);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MedicalClinic>> Create(MedicalClinic clinic)
        {
            var createdClinic = await clinicService.CreateAsync(clinic);
            return CreatedAtAction(nameof(GetById), new { id = createdClinic.Id }, createdClinic);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, MedicalClinic clinic)
        {
            if (id != clinic.Id)
                return BadRequest();

            var result = await clinicService.UpdateAsync(clinic);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await clinicService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}