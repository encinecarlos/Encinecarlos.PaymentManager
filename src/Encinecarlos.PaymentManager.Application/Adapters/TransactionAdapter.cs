using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Adapters
{
    public static class TransactionAdapter
    {
        public static Domain.Entities.Transaction ToEntity(AddTransactionRequest request)
        {
            return new Domain.Entities.Transaction
            {
                Id = Guid.NewGuid(),
                CategoryId = request.Transaction.CategoryId,
                Amount = request.Transaction.Amount,
                Description = request.Transaction.Description,
                Name = request.Transaction.Name,
                IsPaid = request.Transaction.IsPaid,
                IsRecurrency = request.Transaction.IsRecurrency,
                PaymentMethod = request.Transaction.PaymentMethod,
                Type = request.Transaction.Type,
                PaymentOverdue = request.Transaction.PaymentOverdue,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
            };
        }

        public static TransactionDto ToDto(Domain.Entities.Transaction transaction)
        {
            return new TransactionDto
            {
                Name = transaction.Name,
                Description = transaction.Description,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId,
                IsPaid = transaction.IsPaid,
                IsRecurrency = transaction.IsRecurrency,
                PaymentMethod = transaction.PaymentMethod,
            };
        }
    }
}
