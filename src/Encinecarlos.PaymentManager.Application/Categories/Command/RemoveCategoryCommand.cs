using Encinecarlos.PaymentManager.Application.Categories.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public class RemoveCategoryCommand : IRequest<RemoveCategoryDto>
    {
        public Guid CategoryId { get; set; }
    }
}
