using WApp.Domain.Models;
using WApp.Application.DTOs;
using WApp.Application.DTO;
namespace WApp.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto> GetStudentAsync(Guid id);
        Task<Student> AddStudentAsync(AddStudentDto studentdto);
        Task UpdateStudentAsync(Guid id, Student student);
        Task DeleteStudentAsync(Guid id);
        Task DeleteAllStudentsAsync();
        Task<IEnumerable<StudentDto>> AddRandomStudentsAsync(int count, int streamId, int year);
        Task<IEnumerable<SubjectDto>> GetSubjects(int stream, int year);
    }

}

