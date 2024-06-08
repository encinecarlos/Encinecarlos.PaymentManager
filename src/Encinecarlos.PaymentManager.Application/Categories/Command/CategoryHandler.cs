using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public sealed class CategoryHandler : IRequestHandler<AddCategoryDto, CategoryResultDto>
    {
        private readonly IRepository<Category, Guid> _repository;

        public CategoryHandler(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<CategoryResultDto> Handle(AddCategoryDto request, CancellationToken cancellationToken)
        {
            var category = CategoryAdapter.ToEntity(request);
            await _repository.SaveAsync(category);

            var categoryId = CategoryAdapter.ToCategoryDto(category);

            return await Task.FromResult(categoryId);
        }
    }
}
