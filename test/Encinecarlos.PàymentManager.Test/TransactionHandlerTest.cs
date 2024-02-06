using Encinecarlos.PaymentManager.Application.Transaction.Command;
using Encinecarlos.PaymentManager.Application.Transaction.Dto;
using Encinecarlos.PaymentManager.Application.Transaction.Query;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;
using Moq;

namespace Encinecarlos.PàymentManager.Test
{
    public class TransactionHandlerTest
    {
        private Mock<ITransactionRepository> _transactionRepositoryMock;

        public TransactionHandlerTest()
        {
            _transactionRepositoryMock = new();
        }

        [Fact(DisplayName = "Should return list of transactions")]
        public async void ShouldReturnListOfTransactions()
        {
            _transactionRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(ReturnTransactions());

            var testCase = new GetTransactionsHandler(_transactionRepositoryMock.Object);

            var result = await testCase.Handle(new GetTransactionsQuery(), new CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetTransactionsResponse>(result);
        }

        [Fact(DisplayName = "Should save new transaction")]
        public async void ShouldSavetransaction()
        {
            var testCase = new TransactionHandler(_transactionRepositoryMock.Object);

            var result = await testCase.Handle(TransactionRequest(), new CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<AddTransactionResponse>(result);
        }

        [Fact(DisplayName = "Should return transaction By id")]
        public async void ShouldReturnTransactionbyId()
        {
            _transactionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(ReturnSingleTransaction());

            var request = new GetTransactionByIdQuery
            {
                TransactionId = Guid.NewGuid().ToString(),
            };

            var testCase = new GetTransactionByIdHandler(_transactionRepositoryMock.Object);

            var result = await testCase.Handle(request, new CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetTransactionByIdResponse>(result);
        }

        [Fact(DisplayName = "Should update transaction")]
        public async void ShouldUpdateTransaction()
        {
            var testCase = new Updatetransactionhandler(_transactionRepositoryMock.Object);

            var result = await testCase.Handle(UpdateTransactionRequest(), new CancellationToken());

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should delete transaction")]
        public async void ShouldDeleteTransaction()
        {
            var testCase = new RemoveTransactionHandler(_transactionRepositoryMock.Object);

            var result = await testCase.Handle(new RemoveTransactionCommand 
            { 
                TransactionId = Guid.NewGuid().ToString() 
            }, new CancellationToken());

            Assert.NotNull(result);
        }

        private UpdateTransactionCommand UpdateTransactionRequest()
        {
            return new UpdateTransactionCommand
            {
                TransactionId = Guid.NewGuid().ToString(),
                Transaction = new UpdateTransactionRequest
                {
                    Amount = 2,
                }
            };
        }

        private AddTransactionRequest TransactionRequest()
        {
            return new AddTransactionRequest
            {
                Transaction = new AddTransactionDto
                {
                    Name = "name",
                    Amount = 14,
                    CategoryId = "test",
                    Description = "description",
                    IsPaid = false,
                    IsRecurrency = false,
                    PaymentMethod = "Money",
                    PaymentOverdue = DateTime.Now.AddDays(25),
                    Type = "Income"
                }
            };
        }

        private IEnumerable<Transaction> ReturnTransactions()
        {
            return new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Name = "test",
                    Description = "test",
                    Amount = 1,
                    CategoryId = "test",
                    IsPaid = true,
                    IsRecurrency = true,
                    PaymentMethod = PaymentManager.Domain.Enums.PaymentMethod.BankTransfer,
                    PaymentOverdue = DateTime.UtcNow.AddDays(15),
                    Type = PaymentManager.Domain.Enums.TransactionType.Income,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                }
            };
        }
        
        private Transaction ReturnSingleTransaction()
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Description = "test",
                Amount = 1,
                CategoryId = "test",
                IsPaid = true,
                IsRecurrency = true,
                PaymentMethod = PaymentManager.Domain.Enums.PaymentMethod.BankTransfer,
                PaymentOverdue = DateTime.UtcNow.AddDays(15),
                Type = PaymentManager.Domain.Enums.TransactionType.Income,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };            
        }
    }
}