using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Query.Dto
{
    public record CategoryDto(string? Name, string? Description) : IRequest<IEnumerable<GetCategoryResultDto>>;
}
