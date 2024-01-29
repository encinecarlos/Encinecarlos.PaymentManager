using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Enums;
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
                PaymentMethod = Enum.TryParse<PaymentMethod>(request.Transaction.PaymentMethod, out var method) ? method: PaymentMethod.None,
                Type = Enum.TryParse<TransactionType>(request.Transaction.Type, out var type) ? type : TransactionType.None,
                PaymentOverdue = request.Transaction.PaymentOverdue,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
            };
        }
        
        public static Domain.Entities.Transaction ToEntity(string transactionId, UpdateTransactionRequest request)
        {
            return new Domain.Entities.Transaction
            {
                Id = Guid.Parse(transactionId),
                CategoryId = request?.CategoryId,
                Amount = request?.Amount ?? 0,
                Description = request?.Description,
                Name = request?.Name ?? string.Empty,
                IsPaid = request?.IsPaid ?? false,
                IsRecurrency = request?.IsRecurrency ?? false,
                PaymentMethod = Enum.TryParse<PaymentMethod>(request.PaymentMethod, out var method) ? method : PaymentMethod.None,
                Type = Enum.TryParse<TransactionType>(request.Type, out var type) ? type : TransactionType.None,
                PaymentOverdue = request.PaymentOverdue ?? DateTime.UtcNow,
                CreatedAt = null,
                UpdatedAt = DateTime.UtcNow,
            };
        }

        public static TransactionDto ToDto(Domain.Entities.Transaction transaction)
        {
            return new TransactionDto
            {
                TransactionId = transaction.Id.ToString(),
                Name = transaction.Name,
                Description = transaction.Description,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId,
                PaymentOverdue = transaction.PaymentOverdue,
                Type = transaction.Type.ToString(),
                IsPaid = transaction.IsPaid,
                IsRecurrency = transaction.IsRecurrency,
                PaymentMethod = transaction.PaymentMethod.ToString(),
            };
        }
    }
}
