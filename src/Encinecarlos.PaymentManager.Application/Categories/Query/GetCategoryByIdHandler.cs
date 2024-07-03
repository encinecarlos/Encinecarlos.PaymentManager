using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Categories.Query.Dto;
using Encinecarlos.PaymentManager.Application.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Query
{
    public sealed class GetCategoryByIdHandler : IRequestHandler<CategoryByIdDto, GetCategoryResultDto>
    {
        private readonly ICategoryRepository _queryRepository;

        public GetCategoryByIdHandler(ICategoryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<GetCategoryResultDto> Handle(CategoryByIdDto request, CancellationToken cancellationToken)
        {
            var category = await _queryRepository.GetByIdAsync(request.CategoryId);

            var result = CategoryAdapter.MapToGetCategoryResultDto(category);

            return await Task.FromResult(result);            
        }
    }
}
