using CqrsApiMediatr.Domain.Commands.Responses;
using MediatR;

namespace CqrsApiMediatr.Domain.Commands.Requests
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public decimal Value { get; set; }
    }
}
