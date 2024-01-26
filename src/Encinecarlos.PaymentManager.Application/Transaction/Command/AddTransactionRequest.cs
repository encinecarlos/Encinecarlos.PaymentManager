using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Enums;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class AddTransactionRequest : IRequest<AddTransactionResponse>
    {
        public TransactionDto Transaction { get; set; }
    }
}