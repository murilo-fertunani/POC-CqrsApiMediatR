using CqrsApiMediatr.Domain.Entities;
using CqrsApiMediatr.Domain.Queries.Requests;
using CqrsApiMediatr.Infra.Contexts;
using CqrsApiMediatr.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CqrsApiMediatr.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private DbSet<ProductEntity> Entity => _context.Products;
        private IQueryable<ProductEntity> EntityAsNoTracking => Entity.AsNoTracking();

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id, bool asNoTracking = true)
        {
            var query = asNoTracking ? EntityAsNoTracking : Entity;

            return await query
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync(GetAllProductsRequest filter, bool asNoTracking = true)
        {
            var query = asNoTracking ? EntityAsNoTracking : Entity.AsQueryable();

            return await Filter(query, filter).ToListAsync();
        }

        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            await Entity.AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            Entity.Update(entity);
            await SaveAsync();

            return entity;
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private static IQueryable<ProductEntity> Filter(IQueryable<ProductEntity> query, GetAllProductsRequest filter)
        {
            if (filter is null)
                return query;

            if (!string.IsNullOrEmpty(filter.Search))
            {
                var search = filter.Search.ToLower();

                query = query.Where(w => (w.Name.ToLower().Contains(search))
                    || (!string.IsNullOrEmpty(w.BarCode) && w.BarCode.ToLower().Contains(search))
                    || (w.Description.ToLower().Contains(search)));
            }

            if (filter.IsActive.HasValue)
                query = query.Where(w => w.IsActive == filter.IsActive.Value);

            if (filter.MaxCreatedAt.HasValue)
                query = query.Where(w => w.CreatedAt.Date <= filter.MaxCreatedAt.Value.Date);

            if (filter.MinCreatedAt.HasValue)
                query = query.Where(w => w.CreatedAt.Date >= filter.MinCreatedAt.Value.Date);

            if (filter.MaxUpdatedAt.HasValue)
                query = query.Where(w => w.UpdatedAt.Date <= filter.MaxUpdatedAt.Value.Date);

            if (filter.MinUpdatedAt.HasValue)
                query = query.Where(w => w.UpdatedAt.Date >= filter.MinUpdatedAt.Value.Date);

            return query;
        }
    }
}