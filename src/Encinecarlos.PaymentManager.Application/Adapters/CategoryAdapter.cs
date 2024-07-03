using Encinecarlos.PaymentManager.Application.Categories.dto;
using Encinecarlos.PaymentManager.Application.Categories.Query.Dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using CategoryResultDto = Encinecarlos.PaymentManager.Application.Categories.dto.CategoryResultDto;

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

        public static GetCategoryResultDto MapToGetCategoryResultDto(Category category)
        {
            return new GetCategoryResultDto(
                category.Id,
                category.Name,
                category.Description);

        }
    }
}
