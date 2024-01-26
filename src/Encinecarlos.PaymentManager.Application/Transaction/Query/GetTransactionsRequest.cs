using Encinecarlos.PaymentManager.Domain.Enums;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetTransactionsRequest
    {
        public TransactionType Type { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public bool IsPaid { get; set; }
        public bool IsRecurrency { get; set; }
    }
}
