using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DocLink.Entities;

namespace DocLink.Models
{
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }

    public class PaymentTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
