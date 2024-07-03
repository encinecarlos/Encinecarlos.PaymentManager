namespace Encinecarlos.PaymentManager.Application.Categories.Query.Dto
{
    public record GetCategoryResultDto
    (
        Guid CategoryId,
        string Name,
        string? Description
    );
}
