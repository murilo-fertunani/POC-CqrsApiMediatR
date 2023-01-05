namespace CqrsApiMediatr.Domain.Commands.Responses
{
    public class UpdateProductResponse
    {
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public decimal Value { get; set; }
    }
}