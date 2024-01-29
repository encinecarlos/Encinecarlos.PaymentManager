using Encinecarlos.PaymentManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Command
{
    public class AddTransactionDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public string Type { get; init; }
        public string CategoryId { get; set; }
        public decimal Amount { get; init; }
        public string PaymentMethod { get; init; }
        public DateTime PaymentOverdue { get; init; }
        public bool IsPaid { get; set; }
        public bool IsRecurrency { get; set; }
    }
}
