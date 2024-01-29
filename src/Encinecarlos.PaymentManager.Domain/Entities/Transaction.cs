using Encinecarlos.PaymentManager.Domain.Enums;

namespace Encinecarlos.PaymentManager.Domain.Entities
{
    public class Transaction : BaseEntity<Guid>
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public string CategoryId { get; init; }
        public TransactionType Type { get; init; }
        public decimal Amount { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public DateTime PaymentOverdue { get; init; }
        public bool IsPaid { get; set; }
        public bool IsRecurrency { get; set; }

    }
}
