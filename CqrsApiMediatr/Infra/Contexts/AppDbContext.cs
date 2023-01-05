using CqrsApiMediatr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsApiMediatr.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}