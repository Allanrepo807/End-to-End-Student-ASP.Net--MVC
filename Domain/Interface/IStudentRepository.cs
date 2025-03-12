using WApp.Application.DTOs;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(Guid id); // Make return type nullable
        Task<Student> AddStudentAsync(AddStudentDto student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
        Task DeleteAllStudentsAsync();
    }

}