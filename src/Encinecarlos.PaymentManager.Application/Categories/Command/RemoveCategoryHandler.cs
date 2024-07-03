using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Application.Interfaces;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryDto, dto.RemovedCategoryDto>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemovedCategoryDto> Handle(RemoveCategoryDto request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.CategoryId);
            return await Task.FromResult(new RemovedCategoryDto());
        }
    }
}
