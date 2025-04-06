using ASP.Net_API_06._04._2025.Model;

namespace ASP.Net_API_06._04._2025.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task AddAsync(CreateProductDto product);
        Task UpdateAsync(ProductDto product);
        Task DeleteAsync(Guid id);
        Task<List<ProductDto>> GetByNameAsync(string name);
    }
}
