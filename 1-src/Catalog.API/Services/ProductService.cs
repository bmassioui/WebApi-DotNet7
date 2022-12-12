using AutoMapper;
using System.Linq.Expressions;

namespace Catalog.API.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _baseRepository;
    private readonly IMapper _mapper;

    public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper) => (_baseRepository, _mapper) = (baseRepository, mapper);

    public async Task<ReadProduct> AddAsync(AddProduct addProduct)
    {
        var productToCreate = _mapper.Map<Product>(addProduct);

        await _baseRepository.InsertAsync(productToCreate);
        await _baseRepository.SaveChangeAsync();

        return _mapper.Map<ReadProduct>(productToCreate);
    }

    public async Task<ReadProduct?> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ReadProduct?>(await _baseRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<ReadProduct>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "")
    {
        return _mapper.Map<IEnumerable<ReadProduct>>(await _baseRepository.GetAsync(filter, orderBy, includeProperties));
    }

    public async Task<bool> MarkAsDeletedAsync(Guid id)
    {
        var productToDelete = await _baseRepository.GetByIdAsync(id);

        if (productToDelete is null) return false;

        productToDelete.IsDeleted = true;
        _baseRepository.Update(productToDelete);
        await _baseRepository.SaveChangeAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(UpdateProduct updateProduct)
    {
        var productToUpdate = await _baseRepository.GetByIdAsync(updateProduct.Id);

        if (productToUpdate is null) return false;

        productToUpdate = _mapper.Map<Product>(updateProduct);

        _baseRepository.Update(productToUpdate);
        await _baseRepository.SaveChangeAsync();

        return true;
    }
}
