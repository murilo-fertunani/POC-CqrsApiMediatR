using AutoMapper;
using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Commands.Responses;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Domain.Handlers
{
    public class DisableProductHandler : IRequestHandler<DisableProductRequest, DisableProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public DisableProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DisableProductResponse> Handle(DisableProductRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return null;

            entity.IsActive = false;
            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<DisableProductResponse>(entity);
        }
    }
}