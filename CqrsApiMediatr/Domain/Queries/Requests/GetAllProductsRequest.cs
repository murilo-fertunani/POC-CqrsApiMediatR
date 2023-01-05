using CqrsApiMediatr.Domain.Queries.Responses;
using MediatR;

namespace CqrsApiMediatr.Domain.Queries.Requests
{
    public class GetAllProductsRequest : IRequest<IEnumerable<GetAllProductsResponse>>
    {
        public string Search { get; set; }
        public DateTime? MinCreatedAt { get; set; }
        public DateTime? MaxCreatedAt { get; set; }
        public DateTime? MinUpdatedAt { get; set; }
        public DateTime? MaxUpdatedAt { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}