using ASP.Net_API_06._04._2025.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_API_06._04._2025.DAL.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Product product);

        Task<IEnumerable<Product>> GetByNameAsync(string name);
    }
}
