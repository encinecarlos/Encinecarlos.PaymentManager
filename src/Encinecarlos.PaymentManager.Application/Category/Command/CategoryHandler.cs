using Encinecarlos.PaymentManager.Application.Category.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Category.Command
{
    internal class CategoryHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CategoryDto { CateogryId = Guid.NewGuid() });
        }
    }
}
