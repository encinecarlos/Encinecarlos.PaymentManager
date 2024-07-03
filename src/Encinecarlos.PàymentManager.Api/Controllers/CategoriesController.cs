using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Application.Categories.Query;
using Encinecarlos.PaymentManager.Application.Categories.Query.Dto;
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
        public async Task<IEnumerable<GetCategoryResultDto>> GetAll(
            [FromQuery] CategoryDto request,
            CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpPost]
        public async Task<ActionResult<CategoryResultDto>> SaveCategory(
            AddCategoryDto request,
            CancellationToken cancellationToken)
            =>  await _mediator.Send(request, cancellationToken);

        [HttpGet("{categoryId}")]
        public async Task<GetCategoryResultDto> GetById([FromRoute] CategoryByIdDto request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
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
