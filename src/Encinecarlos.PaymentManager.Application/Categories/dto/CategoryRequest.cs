namespace Encinecarlos.PaymentManager.Application.Transaction.dto
{
    public record CategoryRequest
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}
