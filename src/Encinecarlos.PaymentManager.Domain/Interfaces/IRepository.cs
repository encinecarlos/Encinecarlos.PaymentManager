using Encinecarlos.PaymentManager.Domain.Entities;
using System.Linq.Expressions;

namespace Encinecarlos.PaymentManager.Domain.Interfaces
{
    public interface IRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T category);
        Task UpdateAsync(T category);
        Task<T> GetByIdAsync(TId id);
        Task RemoveAsync(TId id);
    }
}
