using Encinecarlos.PaymentManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Dto
{
    public class TransactionDto
    {
        public string TransactionId { get; set; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public TransactionType Type { get; init; }
        public string CategoryId { get; set; }
        public decimal Amount { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public DateTime PaymentOverdue { get; init; }
        public bool IsPaid { get; set; }
        public bool IsRecurrency { get; set; }
    }
}
