using Xunit;
using Moq;
using Encinecarlos.PaymentManager.Application.Categories.Command;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Encinecarlos.PaymentManager.Application.Categories.dto;
using FluentAssertions;
using Encinecarlos.PaymentManager.Application.Interfaces;

namespace Encinecarlos.PaymentManager.tests
{
    public class CategoryHandlerTests
    {
        [Fact(DisplayName = "Should save category on database")]
        public async Task Handle_ShouldCallSaveAsyncOnRepository_WhenCalledWithValidRequest()
        {
            // Arrange
            var mockRepository = new Mock<ICategoryRepository>();
            var handler = new CategoryHandler(mockRepository.Object);
            var request = new AddCategoryDto(It.IsAny<string>(), It.IsAny<string>());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            mockRepository.Verify(repo => repo.SaveAsync(It.IsAny<Category>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<CategoryResultDto>();
        }
    }
}
