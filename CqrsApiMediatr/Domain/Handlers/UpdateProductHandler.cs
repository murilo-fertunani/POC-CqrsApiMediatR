using AutoMapper;
using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Commands.Responses;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using MediatR;

namespace CqrsApiMediatr.Domain.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return null;

            entity = _mapper.Map(request, entity);
            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<UpdateProductResponse>(entity);
        }
    }
}