using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class AddTransactionCommand : IRequest<AddTransactionResponse>
    {
        public AddTransactionRequest Transaction { get; set; }
    }
}
