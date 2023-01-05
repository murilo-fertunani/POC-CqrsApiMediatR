using CqrsApiMediatr.Domain.Queries.Responses;
using MediatR;

namespace CqrsApiMediatr.Domain.Queries.Requests
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public Guid Id { get; set; }
    }
}