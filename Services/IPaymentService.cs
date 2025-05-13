using DocLink.Models;

namespace DocLink.Services
{
    public interface IPaymentService
    {
        Task<PaymentTransaction> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentTransaction>> GetPaymentsByUserAsync(string userId);
        Task AddPaymentAsync(PaymentTransaction payment);
        Task UpdatePaymentAsync(PaymentTransaction payment);
        Task DeletePaymentAsync(int id);
    }
}
