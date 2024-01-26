using Encinecarlos.PaymentManager.Application.Transaction.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetCategoryByIdQuery : IRequest<GetCategoriesDto>
    {
        public GetCategoryByIdRequest Catgory { get; set; }
    }
}
