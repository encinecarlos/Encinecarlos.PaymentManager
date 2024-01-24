using Encinecarlos.PaymentManager.Application.Categories.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Categories.Command
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryDto>
    {
        public Guid CategoryId { get; set; }
        public CategoryRequest Category { get; set; }
    }
}
