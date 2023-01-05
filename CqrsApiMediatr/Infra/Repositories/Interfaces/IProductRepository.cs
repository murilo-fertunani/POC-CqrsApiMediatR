using CqrsApiMediatr.Domain.Entities;
using CqrsApiMediatr.Domain.Queries.Requests;

namespace CqrsApiMediatr.Infra.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetByIdAsync(Guid id, bool asNoTracking = true);
        Task<IEnumerable<ProductEntity>> GetAllAsync(GetAllProductsRequest filter, bool asNoTracking = true);
        Task<ProductEntity> AddAsync(ProductEntity entity);
        Task<ProductEntity> UpdateAsync(ProductEntity entity);
    }
}