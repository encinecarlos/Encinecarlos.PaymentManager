using Encinecarlos.PaymentManager.Application.Transaction.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Encinecarlos.PaymentManager.Application.Adapters
{
    public static class CategoryAdapter
    {
        public static Category ToEntity(CategoryRequest request)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
                       
        }
        
        public static Category ToEntity(Guid categoryId, CategoryRequest request)
        {
            return new Category
            {
                Id = categoryId,
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                UpdatedAt = DateTime.UtcNow
            };
                       
        }

        public static CategoryDto ToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                CateogryId = category.Id,
            };
        }

        public static GetCategoriesDto ToDto(Category category)
        {
            return new GetCategoriesDto
            {
                CategoryId = category.Id,
                Name = category.Name,
                Description = category.Description ?? string.Empty,
            };
        }
    }
}
