// Services/PaymentTransactionService.cs
using DocLink.Data;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class PaymentTransactionService(UserDbContext context) : IPaymentTransactionService
    {
        public async Task<PaymentTransaction> CreateAsync(PaymentTransaction payment)
        {
            context.PaymentTransactions.Add(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task<PaymentTransaction?> GetByAppointmentAsync(int appointmentId)
        {
            return await context.PaymentTransactions
                .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);
        }

        public async Task<IEnumerable<PaymentTransaction>> GetByUserAsync(int userId)
        {
            return await context.PaymentTransactions
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<PaymentTransaction?> GetByIdAsync(int id)
        {
            return await context.PaymentTransactions.FindAsync(id);
        }

        public async Task<bool> UpdateStatusAsync(int id, PaymentStatus status)
        {
            var payment = await context.PaymentTransactions.FindAsync(id);
            if (payment is null)
                return false;

            payment.Status = status;
            return await context.SaveChangesAsync() > 0;
        }
    }
}