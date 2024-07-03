using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Query.Dto
{
    public record CategoryByIdDto(Guid CategoryId) : IRequest<GetCategoryResultDto>;
    
    
}
