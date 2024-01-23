using Encinecarlos.PaymentManager.Application.Categories.Command;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Application.Categories.Query;
using MediatR;
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

        [HttpGet]
        public async Task<IEnumerable<GetCategoriesDto>> GetAll([FromQuery] GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCategoriesQuery { Filters = request }, cancellationToken);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> GetCategories(CategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AddCategoryCommand { Category = request }, cancellationToken);
            return response;
        }
    }
}
