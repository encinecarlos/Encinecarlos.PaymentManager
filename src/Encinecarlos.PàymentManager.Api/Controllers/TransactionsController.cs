using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encinecarlos.PàymentManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetTransactionsResponse> GetTransactions() 
            => await _mediator.Send(new GetTransactionsQuery());

        [HttpPost]
        public async Task<AddTransactionResponse> SaveTransaction(AddTransactionRequest request, CancellationToken cancellationToken) 
            => await _mediator.Send(new AddTransactionCommand { Transaction = request }, cancellationToken);

        [HttpGet("{transactionId}")]
        public async Task<GetTransactionByIdResponse> GetById(string transactionId)
        {
            return await _mediator.Send(new GetTransactionByIdQuery { TransactionId = transactionId });
        }

        [HttpPatch("{transactionId}")]
        public async Task<GetTransactionByIdResponse> UpdateTransaction(string transactionId)
        {
             
        }

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> RemoveTransaction(string transactionId)
        {  
            return Ok();
        }

    }
}
