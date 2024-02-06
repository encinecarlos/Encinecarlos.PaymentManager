using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Application.Transaction.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encinecarlos.PaymentManager.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetTransactionsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTransactionsResponse>> GetTransactions()
            => await _mediator.Send(new GetTransactionsQuery());

        [HttpPost]
        [ProducesResponseType(typeof(AddTransactionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AddTransactionResponse>> SaveTransaction(AddTransactionRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AddTransactionCommand { Transaction = request }, cancellationToken);
            return Created($"/api/Transactions/{response.TransactionId}", response);
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(typeof(GetTransactionByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTransactionByIdResponse>> GetById(string transactionId)
        {
            return await _mediator.Send(new GetTransactionByIdQuery { TransactionId = transactionId });
        }

        [HttpPatch("{transactionId}")]
        [ProducesResponseType(typeof(UpdateTransactionResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTransaction(string transactionId, UpdateTransactionRequest request)
        {
            await _mediator.Send(new UpdateTransactionCommand 
            { 
                Transaction = request, TransactionId = transactionId 
            });

            return NoContent();
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveTransaction(string transactionId)
        {
            await _mediator.Send(new RemoveTransactionCommand { TransactionId = transactionId });
            return NoContent();
        }

    }
}
