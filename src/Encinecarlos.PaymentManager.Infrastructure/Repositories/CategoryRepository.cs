using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using Encinecarlos.PaymentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Encinecarlos.PaymentManager.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category, Guid>
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() 
            => await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(Guid id) => 
            await _context.Categories.FirstOrDefaultAsync(x => x.Id == id) ?? new Category();

        public async Task RemoveAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public async Task SaveAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
