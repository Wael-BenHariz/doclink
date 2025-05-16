// Services/Interfaces/IPaymentTransactionService.cs
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IPaymentTransactionService
    {
        Task<IEnumerable<PaymentTransaction>> GetByUserAsync(int userId);
        Task<PaymentTransaction?> GetByAppointmentAsync(int appointmentId);
        Task<PaymentTransaction?> GetByIdAsync(int id);
        Task<PaymentTransaction> CreateAsync(PaymentTransaction payment);
        Task<bool> UpdateStatusAsync(int id, PaymentStatus status);
    }
}