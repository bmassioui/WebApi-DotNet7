using System.Linq.Expressions;

namespace Catalog.API.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Add product asynchronously
        /// </summary>
        /// <param name="addProduct">Product to add</param>
        /// <returns></returns>
        Task<ReadProduct> AddAsync(AddProduct addProduct);

        /// <summary>
        /// Get product by ID asynchronously
        /// </summary>
        /// <param name="id">Product identitifer</param>
        /// <returns></returns>
        Task<ReadProduct?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get products asynchronously
        /// </summary>
        /// <param name="filter">Filter the result</param>
        /// <param name="orderBy">Order the result</param>
        /// <param name="includeProperties">Include properties into the result, supports multiple properties separated by ',' character</param>
        /// <returns></returns>
        Task<IEnumerable<ReadProduct>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "");

        /// <summary>
        /// Mark product as soft deleted
        /// </summary>
        /// <param name="id">Product's ID</param>
        /// <returns>True if the deletion done, else False if no product could be found</returns>
        Task<bool> MarkAsDeletedAsync(Guid id);

        /// <summary>
        /// Update product asynchronously
        /// </summary>
        /// <param name="updateProduct">Product to update</param>
        /// <returns>True if the update done, else False if no product could be found</returns>
        Task<bool> UpdateAsync(UpdateProduct updateProduct);
    }
}