using Encinecarlos.PaymentManager.Application.Categories.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Query
{
    public class GetCategoryByIdQuery : IRequest<GetCategoriesDto>
    {
        public GetCategoryByIdRequest Catgory { get; set; }
    }
}
