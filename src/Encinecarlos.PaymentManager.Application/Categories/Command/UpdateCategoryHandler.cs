using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Application.Interfaces;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryDto, UpdatedCategoryDto>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
        {
            var category = CategoryAdapter.ToEntity(request);
            await _repository.UpdateAsync(category);
            return await Task.FromResult(new UpdatedCategoryDto());
        }
    }
}
