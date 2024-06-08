using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Encinecarlos.PaymentManager.Application.Adapters
{
    public static class CategoryAdapter
    {
        public static Category ToEntity(AddCategoryDto request)
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
        
        public static Category ToEntity(UpdateCategoryDto request)
        {
            return new Category
            {
                Id = request.CategoryId,
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                UpdatedAt = DateTime.UtcNow
            };
                       
        }

        public static CategoryResultDto ToCategoryDto(Category category)
        {
            return new CategoryResultDto
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
