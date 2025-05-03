using ASP.Net_API_06._04._2025.Model;

namespace ASP.Net_API_06._04._2025.Abstract
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task AddAsync(StudentDto student);
        Task UpdateAsync(StudentDto student);
        Task DeleteAsync(Guid id);
        Task<List<StudentDto>> GetByNameAsync(string name);
    }
}
