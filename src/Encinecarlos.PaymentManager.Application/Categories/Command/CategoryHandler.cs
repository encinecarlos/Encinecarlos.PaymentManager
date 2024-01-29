using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    internal class CategoryHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        private readonly IRepository<Category, Guid> _repository;

        public CategoryHandler(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = CategoryAdapter.ToEntity(request.Category);
            await _repository.SaveAsync(category);

            var categoryId = CategoryAdapter.ToCategoryDto(category);

            return await Task.FromResult(categoryId);
        }
    }
}
