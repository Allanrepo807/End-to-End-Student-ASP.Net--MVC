using Microsoft.AspNetCore.Mvc;
using WApp.Services;
using WApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using WApp.Application.DTOs;

namespace WApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            try
            {
                var student = await _studentService.GetStudentAsync(id);
                return Ok(student);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(AddStudentDto studentdto)
        {
            var createdStudent = await _studentService.AddStudentAsync(studentdto);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.ID }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            try
            {
                await _studentService.UpdateStudentAsync(id, student);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearAllStudents()
        {
            await _studentService.DeleteAllStudentsAsync();
            return NoContent();
        }

        [HttpPost("random")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> AddRandomStudents([FromBody] RandomStudentRequest request)
        {
            if (request.Count <= 0 || request.Count > 50)
            {
                return BadRequest("Number of random students must be between 1 and 20");
            }

            var addedStudents = await _studentService.AddRandomStudentsAsync(
                request.Count,
                request.StreamId,
                request.Year
            );

            return Ok(addedStudents);
        }
        public class RandomStudentRequest
        {
            public int Count { get; set; } = 5; // Default to 5 if not specified
            public int StreamId { get; set; }
            public int Year { get; set; }
        }
    }


}