using ASP.Net_API_06._04._2025.Abstract;
using ASP.Net_API_06._04._2025.DAL.Abstract;
using ASP.Net_API_06._04._2025.DAL.Entities;
using ASP.Net_API_06._04._2025.Model;

namespace ASP.Net_API_06._04._2025.Core
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(StudentDto student)
        {

            var st = new Student
            {
                Id = Guid.NewGuid(),
                FullName = student.FullName,
                Group = student.Group
            };
           
            await _repository.AddAsync(st);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var studentsDto = new List<StudentDto>();

            var result = await _repository.GetAllAsync();

            foreach (var student in result)
            {
                studentsDto.Add(new StudentDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Group = student.Group,

                });
            }

            return studentsDto;
        }

        public async Task UpdateAsync(StudentDto student)
        {
            var st = new Student
            {
                Id = student.Id,
                FullName = student.FullName,
                Group = student.Group
            };

            await _repository.UpdateAsync(st);
        }

        public async Task<List<StudentDto>> GetByNameAsync(string name)
        {
            var studentsDto = new List<StudentDto>();
            var result = await _repository.GetByNameAsync(name);
            foreach (var student in result)
            {
                studentsDto.Add(new StudentDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Group = student.Group
                });
            }
            return studentsDto;
        }
    }
}