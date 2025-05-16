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
    public class DoctorReviewController(IDoctorReviewService reviewService) : ControllerBase
    {
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<DoctorReview>>> GetByDoctor(int doctorId)
        {
            var reviews = await reviewService.GetByDoctorAsync(doctorId);
            return Ok(reviews);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<DoctorReview>>> GetByPatient(int patientId)
        {
            var reviews = await reviewService.GetByPatientAsync(patientId);
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorReview>> GetById(int id)
        {
            var review = await reviewService.GetByIdAsync(id);
            if (review is null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<DoctorReview>> Create(DoctorReview review)
        {
            var createdReview = await reviewService.CreateAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Update(int id, DoctorReview review)
        {
            if (id != review.Id)
                return BadRequest();

            var result = await reviewService.UpdateAsync(review);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await reviewService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}