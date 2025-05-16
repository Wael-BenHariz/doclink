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
    public class PaymentTransactionController(IPaymentTransactionService paymentService) : ControllerBase
    {
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PaymentTransaction>>> GetByUser(int userId)
        {
            var payments = await paymentService.GetByUserAsync(userId);
            return Ok(payments);
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<ActionResult<PaymentTransaction>> GetByAppointment(int appointmentId)
        {
            var payment = await paymentService.GetByAppointmentAsync(appointmentId);
            if (payment is null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTransaction>> GetById(int id)
        {
            var payment = await paymentService.GetByIdAsync(id);
            if (payment is null)
                return NotFound();

            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentTransaction>> Create(PaymentTransaction payment)
        {
            var createdPayment = await paymentService.CreateAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = createdPayment.Id }, createdPayment);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] PaymentStatus status)
        {
            var result = await paymentService.UpdateStatusAsync(id, status);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}