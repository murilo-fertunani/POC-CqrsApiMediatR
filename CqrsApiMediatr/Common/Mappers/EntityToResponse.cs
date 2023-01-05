using AutoMapper;
using CqrsApiMediatr.Domain.Entities;
using CqrsApiMediatr.Domain.Queries.Requests;

namespace CqrsApiMediatr.Common.Mappers
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<ProductEntity, GetProductByIdRequest>();
        }
    }
}