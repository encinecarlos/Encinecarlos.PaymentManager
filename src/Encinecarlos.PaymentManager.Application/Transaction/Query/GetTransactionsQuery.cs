using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionsQuery : IRequest<GetTransactionsResponse>
    {
        public GetTransactionsRequest Filters { get; set; }
    }
}
