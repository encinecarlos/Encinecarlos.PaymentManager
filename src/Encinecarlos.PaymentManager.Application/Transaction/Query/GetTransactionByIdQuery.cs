using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionByIdQuery : IRequest<GetTransactionByIdResponse>
    {
        public string TransactionId { get; init; }
    }
}
