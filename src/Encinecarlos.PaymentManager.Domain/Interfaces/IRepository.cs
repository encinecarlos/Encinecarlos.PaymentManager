using Encinecarlos.PaymentManager.Domain.Entities;
using System.Linq.Expressions;

namespace Encinecarlos.PaymentManager.Domain.Interfaces
{
    public interface IRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T data);
        Task UpdateAsync(T data);
        Task<T> GetByIdAsync(TId id);
        Task RemoveAsync(TId id);
    }
}
