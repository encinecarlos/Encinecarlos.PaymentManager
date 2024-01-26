using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionByIdResponse
    {
        public TransactionDto Transaction { get; init; }
    }
}
