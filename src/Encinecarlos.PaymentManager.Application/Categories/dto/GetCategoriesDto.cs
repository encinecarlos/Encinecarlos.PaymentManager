namespace Encinecarlos.PaymentManager.Application.Transaction.dto
{
    public class GetCategoriesDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
