namespace CqrsApiMediatr.Domain.Commands.Responses
{
    public class EnableProductResponse
    {
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}