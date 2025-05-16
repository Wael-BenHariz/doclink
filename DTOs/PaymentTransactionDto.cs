// Models/DTOs/PaymentTransactionDto.cs
using DocLink.Models;

namespace DocLink.DTOs
{
    public class PaymentTransactionDto
    {
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }

    public class PaymentStatusUpdateDto
    {
        public PaymentStatus Status { get; set; }
    }
}