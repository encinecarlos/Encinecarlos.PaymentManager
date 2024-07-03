using MediatR;
using System.Text.Json.Serialization;

namespace Encinecarlos.PaymentManager.Application.Categories.dto
{
    public record UpdateCategoryDto : IRequest<UpdatedCategoryDto>
    {
        [JsonIgnore]
        public Guid CategoryId { get; set; }
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
