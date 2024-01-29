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
    public class Updatetransactionhandler : IRequestHandler<UpdateTransactionCommand, UpdateTransactionResponse>
    {
        private readonly ITransactionRepository _repository;

        public Updatetransactionhandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateTransactionResponse> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = TransactionAdapter.ToEntity(request.TransactionId, request.Transaction);
            await _repository.UpdateAsync(transaction);
            return await Task.FromResult(new UpdateTransactionResponse());
        }
    }
}
