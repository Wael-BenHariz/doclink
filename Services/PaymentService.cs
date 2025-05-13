using DocLink.Data;
using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly UserDbContext _context;

        public PaymentService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentTransaction> GetPaymentByIdAsync(int id)
        {
            return await _context.PaymentTransactions.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentTransaction>> GetPaymentsByUserAsync(string userId)
        {
            return await _context.PaymentTransactions
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task AddPaymentAsync(PaymentTransaction payment)
        {
            _context.PaymentTransactions.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(PaymentTransaction payment)
        {
            _context.PaymentTransactions.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _context.PaymentTransactions.FindAsync(id);
            if (payment != null)
            {
                _context.PaymentTransactions.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
