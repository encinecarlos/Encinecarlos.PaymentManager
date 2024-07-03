using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using System.Security.Cryptography;

namespace Encinecarlos.PaymentManager.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task SaveAsync(Category category);
        Task UpdateAsync(Category category);
        Task<Category> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}
