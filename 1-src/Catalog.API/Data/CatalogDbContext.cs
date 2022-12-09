using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data;

public class CatalogDbContext : DbContext
{
    protected CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
