using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet("doctor/{doctorId}")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetByDoctor(int doctorId)
        {
            var appointments = await appointmentService.GetByDoctorAsync(doctorId);
            return Ok(appointments);
        }

        [HttpGet("patient/{patientId}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetByPatient(int patientId)
        {
            var appointments = await appointmentService.GetByPatientAsync(patientId);
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(int id)
        {
            var appointment = await appointmentService.GetByIdAsync(id);
            if (appointment is null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<Appointment>> Create(Appointment appointment)
        {
            var createdAppointment = await appointmentService.CreateAsync(appointment);
            return CreatedAtAction(nameof(GetById), new { id = createdAppointment.Id }, createdAppointment);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] AppointmentStatus status)
        {
            var result = await appointmentService.UpdateStatusAsync(id, status);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await appointmentService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}