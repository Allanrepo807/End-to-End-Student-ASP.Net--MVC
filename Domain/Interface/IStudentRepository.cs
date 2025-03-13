using WApp.Application.DTOs;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto?> GetStudentAsync(Guid id); // Make return type nullable
        Task<Student> AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
        Task DeleteAllStudentsAsync();
    }

}