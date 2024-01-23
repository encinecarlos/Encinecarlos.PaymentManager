using Encinecarlos.PaymentManager.Application.Categories.dto;
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
