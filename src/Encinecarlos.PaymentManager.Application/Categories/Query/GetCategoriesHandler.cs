using Encinecarlos.PaymentManager.Application.Categories.Query.Dto;
using Encinecarlos.PaymentManager.Application.Interfaces;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Query
{
    public sealed class GetCategoriesHandler : IRequestHandler<CategoryDto, IEnumerable<GetCategoryResultDto>>
    {
        private readonly ICategoryRepository _queryRepository;

        public GetCategoriesHandler(ICategoryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<GetCategoryResultDto>> Handle(
            CategoryDto request,
            CancellationToken cancellationToken)
        {
            var categories = await _queryRepository.GetAllAsync();

            if (request.Name is not null || request.Description is not null)
            {
                var filteredCategories = categories.Where(x =>
                x.Name == request.Name
                || x.Description == request.Description);

                return await Task.FromResult(MapResponse(filteredCategories));
            }

            return await Task.FromResult(MapResponse(categories));
        }

        private IEnumerable<GetCategoryResultDto> MapResponse(IEnumerable<Category> categories)
        {
            return categories.Select(x => new GetCategoryResultDto
            (
                x.Id,
                x.Name,
                x.Description
            ));
        }
    }
}
