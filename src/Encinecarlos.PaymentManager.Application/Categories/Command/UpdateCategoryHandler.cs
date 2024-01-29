using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDto>
    {
        private readonly IRepository<Category, Guid> _repository;

        public UpdateCategoryHandler(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = CategoryAdapter.ToEntity(request.CategoryId, request.Category);
            await _repository.UpdateAsync(category);
            return await Task.FromResult(new UpdateCategoryDto());
        }
    }
}
