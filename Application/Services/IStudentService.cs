using System.Collections.Generic;
using System.Threading.Channels;
using WApp.Domain.Models;
namespace WApp.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid id);
        Task<Student> AddStudentAsync(Student student);
        Task UpdateStudentAsync(Guid id, Student student);
        Task DeleteStudentAsync(Guid id);
        Task DeleteAllStudentsAsync();

    }
}
