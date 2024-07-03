using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.dto
{
    public record RemoveCategoryDto : IRequest<RemovedCategoryDto>
    {
        public Guid CategoryId { get; set; }
    }
}
