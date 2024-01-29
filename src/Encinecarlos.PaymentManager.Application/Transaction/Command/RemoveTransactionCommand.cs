using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class RemoveTransactionCommand : IRequest<RemoveTransactionResponse>
    {
        public string TransactionId { get; set; }
    }
}
