using WApp.Domain.Interfaces;
using WApp.Domain.Models;


namespace WApp.Application.UseCases
{
    public class AddStudentUseCase
    {
        private readonly IStudentRepository _repository;

        public AddStudentUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Student> Execute(Student student)
        {
            student.ID = Guid.NewGuid();
            return await _repository.AddStudentAsync(student);
        }
    }
}