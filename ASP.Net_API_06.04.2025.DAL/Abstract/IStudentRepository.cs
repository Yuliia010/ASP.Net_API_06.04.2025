using ASP.Net_API_06._04._2025.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_API_06._04._2025.DAL.Abstract
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Student student);

        Task<IEnumerable<Student>> GetByNameAsync(string name);
    }
}
