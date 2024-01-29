using Encinecarlos.PaymentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Domain.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction?, Guid>
    {
    }
}
