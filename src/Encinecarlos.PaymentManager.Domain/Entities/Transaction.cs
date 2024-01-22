namespace Encinecarlos.PaymentManager.Domain.Entities
{
    internal class Transaction : BaseEntity<Guid>
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public Category MyProperty { get; set; }
    }
}
