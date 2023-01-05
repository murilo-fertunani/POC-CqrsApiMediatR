using AutoMapper;
using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Entities;

namespace CqrsApiMediatr.Common.Mappers
{
    public class RequestToEntity : Profile
    {
        public RequestToEntity()
        {
            CreateMap<CreateProductRequest, ProductEntity>();
            CreateMap<UpdateProductRequest, ProductEntity>();
        }
    }
}