namespace CqrsApiMediatr.Domain.Commands.Responses
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public decimal Value { get; set; }
    }
}