using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class TransactionHandler : IRequestHandler<AddTransactionCommand, AddTransactionResponse>
    {
        private readonly ITransactionRepository _repository;

        public TransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddTransactionResponse> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = TransactionAdapter.ToEntity(request.Transaction);
            await _repository.SaveAsync(transaction);
            return await Task.FromResult(new AddTransactionResponse());
        }
    }
}
