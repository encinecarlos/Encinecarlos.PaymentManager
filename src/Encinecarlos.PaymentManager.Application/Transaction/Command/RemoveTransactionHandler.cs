using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class RemoveTransactionHandler : IRequestHandler<RemoveTransactionCommand, RemoveTransactionResponse>
    {
        private readonly ITransactionRepository _repository;

        public RemoveTransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveTransactionResponse> Handle(RemoveTransactionCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(Guid.Parse(request.TransactionId));
            return await Task.FromResult(new RemoveTransactionResponse());
        }
    }
}
