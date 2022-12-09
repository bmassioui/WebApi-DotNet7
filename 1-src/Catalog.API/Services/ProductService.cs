using System.Linq.Expressions;

namespace Catalog.API.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _baseRepository;
    private readonly ICatalogUoW _catalogUoW;

    public ProductService(IBaseRepository<Product> baseRepository, ICatalogUoW catalogUoW)
    {
        _baseRepository = baseRepository;
        _catalogUoW = catalogUoW;
    }

    public async Task AddAsync(Product product)
    {
        await _baseRepository.InsertAsync(product);
        await _catalogUoW.CommitAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _baseRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "")
    {
        return await _baseRepository.GetAsync(filter, orderBy, includeProperties);
    }

    public async Task MarkAsDeleted(Product product)
    {
        product.IsDeleted = true;
        await UpdateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        _baseRepository.Update(product);
        await _catalogUoW.CommitAsync();
    }
}
