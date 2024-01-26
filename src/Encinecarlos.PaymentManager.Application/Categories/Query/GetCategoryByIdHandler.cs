using Encinecarlos.PaymentManager.Application.Adapters;
using Encinecarlos.PaymentManager.Application.Transaction.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoriesDto>
    {
        private readonly IRepository<Category, Guid> _repository;

        public GetCategoryByIdHandler(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoriesDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Catgory.CategoryId);

            var categoryAdapted = CategoryAdapter.ToDto(category); 

            return await Task.FromResult(categoryAdapted);
        }
    }
}
