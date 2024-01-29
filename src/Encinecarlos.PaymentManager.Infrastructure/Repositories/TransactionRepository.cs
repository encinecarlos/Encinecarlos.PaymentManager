using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using Encinecarlos.PaymentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction?>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync(Transaction? data)
        {
            _context.Transactions.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction? data)
        {
            var transaction = await _context.Transactions.FindAsync(data.Id);
            _context.Entry(transaction).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
        }
    }
}
