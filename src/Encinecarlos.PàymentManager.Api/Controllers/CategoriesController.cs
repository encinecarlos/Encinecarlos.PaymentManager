using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.dto;
using Encinecarlos.PaymentManager.Application.Transaction.Query;
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

        [HttpGet("{categoryId}")]
        public async Task<GetCategoriesDto> GetById([FromRoute] GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery { Catgory =  request }, cancellationToken);
            return response;
        }

        [HttpPut("{categoryId}")]
        public async Task<UpdateCategoryDto> UpdateCategory([FromRoute] Guid categoryId, CategoryRequest category, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new UpdateCategoryCommand { CategoryId = categoryId, Category = category }, cancellationToken);
            return response;
        }

        [HttpDelete("{categoryId}")]
        public async Task<RemoveCategoryDto> RemoveCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new RemoveCategoryCommand { CategoryId = categoryId }, cancellationToken);
            return response;
        }
    }
}
