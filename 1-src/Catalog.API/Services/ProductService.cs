using AutoMapper;
using System.Linq.Expressions;

namespace Catalog.API.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _baseRepository;
    private readonly IMapper _mapper;

    public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper) => (_baseRepository, _mapper) = (baseRepository, mapper);

    public async Task AddAsync(Product product)
    {
        await _baseRepository.InsertAsync(product);
        await _baseRepository.SaveChangeAsync();
    }

    public async Task<ReadProduct?> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ReadProduct?>(await _baseRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<ReadProduct>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "")
    {
        return _mapper.Map<IEnumerable<ReadProduct>>(await _baseRepository.GetAsync(filter, orderBy, includeProperties));
    }

    public async Task MarkAsDeleted(Product product)
    {
        product.IsDeleted = true;
        await UpdateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        _baseRepository.Update(product);
        await _baseRepository.SaveChangeAsync();
    }
}
