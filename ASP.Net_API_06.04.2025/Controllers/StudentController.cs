using ASP.Net_API_06._04._2025.Abstract;
using ASP.Net_API_06._04._2025.Model;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_API_06._04._2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {

        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            
            try
            {
                var students = await _studentService.GetAllAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetByName(string name)
        {
            try
            {
                var students = await _studentService.GetByNameAsync(name);

                if (students == null || !students.Any())
                {
                    return NotFound("Students not found");
                }

                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create([FromBody] StudentDto dto)
        {
            try
            {

                await _studentService.AddAsync(dto);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<StudentDto>> Update([FromBody] StudentDto dto)
        {
            try
            {
                await _studentService.UpdateAsync(dto);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePost([FromBody] StudentDto dto)
        {
            try
            {
                await _studentService.UpdateAsync(dto);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> Delete(Guid id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}

