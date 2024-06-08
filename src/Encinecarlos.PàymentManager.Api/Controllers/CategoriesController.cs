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
        public async Task<ActionResult<CategoryResultDto>> GetCategories(AddCategoryDto request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return response;
        }

        [HttpGet("{categoryId}")]
        public async Task<GetCategoriesDto> GetById([FromRoute] GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery { Catgory =  request }, cancellationToken);
            return response;
        }

        [HttpPut("{categoryId}")]
        public async Task<UpdatedCategoryDto> UpdateCategory([FromRoute] Guid categoryId, UpdateCategoryDto category, CancellationToken cancellationToken)
        {
            category.CategoryId = categoryId;
            var response = await _mediator.Send(category, cancellationToken);
            return response;
        }

        [HttpDelete("{categoryId}")]
        public async Task<RemovedCategoryDto> RemoveCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new RemoveCategoryDto { CategoryId = categoryId }, cancellationToken);
            return response;
        }
    }
}
