using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class UpdateTransactionCommand : IRequest<UpdateTransactionResponse>
    {
        public UpdateTransactionRequest transaction { get; set; }
    }
}
