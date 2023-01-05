using AutoMapper;
using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Commands.Responses;
using CqrsApiMediatr.Domain.Entities;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Domain.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductEntity>(request);

            entity = await _repository.AddAsync(entity);

            return _mapper.Map<CreateProductResponse>(entity);
        }
    }
}