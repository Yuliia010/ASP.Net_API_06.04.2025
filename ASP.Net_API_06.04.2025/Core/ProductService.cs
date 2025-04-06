using ASP.Net_API_06._04._2025.Abstract;
using ASP.Net_API_06._04._2025.DAL.Abstract;
using ASP.Net_API_06._04._2025.DAL.Entities;
using ASP.Net_API_06._04._2025.Model;

namespace ASP.Net_API_06._04._2025.Core
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CreateProductDto product)
        {

            var pr = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price
            };
            await _repository.AddAsync(pr);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var productsDto = new List<ProductDto>();

            var result = await _repository.GetAllAsync();

            foreach (var product in result)
            {
                productsDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    
                });
            }

            return productsDto;
        }

        public async Task UpdateAsync(ProductDto product)
        {
            var pr = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            await _repository.UpdateAsync(pr);
        }

        public async Task<List<ProductDto>> GetByNameAsync(string name)
        {
            var productsDto = new List<ProductDto>();
            var result = await _repository.GetByNameAsync(name);
            foreach (var product in result)
            {
                productsDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            return productsDto;
        }
    }
}
