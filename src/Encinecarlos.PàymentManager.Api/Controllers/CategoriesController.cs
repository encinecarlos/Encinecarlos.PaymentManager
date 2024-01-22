using Encinecarlos.PaymentManager.Application.Category.Command;
using Encinecarlos.PaymentManager.Application.Category.dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encinecarlos.PàymentManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> GetCategories(CategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AddCategoryCommand { Category = request }, cancellationToken);
            return response;
        }
    }
}
