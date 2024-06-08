using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.dto
{
    public record AddCategoryDto(string Name, string Description) : IRequest<CategoryResultDto>;
}
