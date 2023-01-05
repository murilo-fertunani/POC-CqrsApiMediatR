using CqrsApiMediatr.Domain.Commands.Responses;
using MediatR;

namespace CqrsApiMediatr.Domain.Commands.Requests
{
    public class EnableProductRequest : IRequest<EnableProductResponse>
    {
        public Guid Id { get; set; }
    }
}