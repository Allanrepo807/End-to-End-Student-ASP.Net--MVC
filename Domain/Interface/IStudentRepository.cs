using WApp.Domain.Models;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<Student> GetStudentAsync(Guid id);
    Task<Student> AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(Guid id);
    Task DeleteAllStudentsAsync();
}