using AutoMapper;
using CqrsApiMediatr.Domain.Queries.Requests;
using CqrsApiMediatr.Domain.Queries.Responses;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Domain.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(request);

            return _mapper.Map<IEnumerable<GetAllProductsResponse>>(entities);
        }
    }
}