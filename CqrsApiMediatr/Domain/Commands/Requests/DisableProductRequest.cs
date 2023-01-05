using CqrsApiMediatr.Domain.Commands.Responses;
using MediatR;

namespace CqrsApiMediatr.Domain.Commands.Requests
{
    public class DisableProductRequest : IRequest<DisableProductResponse>
    {
        public Guid Id { get; set; }
    }
}