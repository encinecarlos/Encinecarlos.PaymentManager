using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdResponse>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionByIdHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTransactionByIdResponse> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _repository.GetByIdAsync(Guid.Parse(request.TransactionId));

            if(transaction is null)
            {
                return await Task.FromResult(new GetTransactionByIdResponse());
            }

            var transactionDto = TransactionAdapter.ToDto(transaction);
            return await Task.FromResult(new GetTransactionByIdResponse { Transaction = transactionDto });
        }
    }
}
