using Encinecarlos.PaymentManager.Application.Transaction.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryDto>
    {
        public Guid CategoryId { get; set; }
        public CategoryRequest Category { get; set; }
    }
}
