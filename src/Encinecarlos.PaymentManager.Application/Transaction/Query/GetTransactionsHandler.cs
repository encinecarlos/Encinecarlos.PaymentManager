using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, GetTransactionsResponse>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTransactionsResponse> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetAllAsync();

            return await Task.FromResult(new GetTransactionsResponse { Transactions = MapFields(transactions) });
        }

        private IEnumerable<TransactionDto> MapFields(IEnumerable<Domain.Entities.Transaction> transactions)
        {
            List<TransactionDto> result = new();
            foreach(var transaction in transactions)
            {
                result.Add(new TransactionDto
                {
                    TransactionId = transaction.Id.ToString(),
                    Name = transaction.Name,
                    Amount = transaction.Amount,
                    CategoryId = transaction.CategoryId,
                    Description = transaction.Description,
                    IsPaid = transaction.IsPaid,
                    IsRecurrency = transaction.IsRecurrency,
                    PaymentMethod = transaction.PaymentMethod.ToString(),
                    PaymentOverdue = transaction.PaymentOverdue,
                    Type = transaction.Type.ToString(),
                });
            }

            return result;
        }
    }
}
