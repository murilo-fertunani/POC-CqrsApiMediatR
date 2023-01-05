namespace CqrsApiMediatr.Domain.Commands.Responses
{
    public class DisableProductResponse
    {
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}