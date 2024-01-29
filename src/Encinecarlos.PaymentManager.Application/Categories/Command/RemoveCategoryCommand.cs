using Encinecarlos.PaymentManager.Application.Transaction.dto;
using MediatR;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class RemoveCategoryCommand : IRequest<RemoveCategoryDto>
    {
        public Guid CategoryId { get; set; }
    }
}
