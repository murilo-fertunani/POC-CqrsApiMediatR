using AutoMapper;
using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Commands.Responses;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Domain.Handlers
{
    public class EnableProductHandler : IRequestHandler<EnableProductRequest, EnableProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public EnableProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EnableProductResponse> Handle(EnableProductRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return null;

            entity.IsActive = true;
            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<EnableProductResponse>(entity);
        }
    }
}