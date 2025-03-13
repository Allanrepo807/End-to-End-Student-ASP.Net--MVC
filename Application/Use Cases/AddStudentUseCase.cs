using WApp.Application.DTOs;
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

        public async Task<Student> Execute(AddStudentDto studentdto)
        {
            var student = new Student
            {
                ID = Guid.NewGuid(),
                Name = studentdto.Name,
                Year = studentdto.Year,
                StreamId = studentdto.StreamId,
                Gender = studentdto.Gender
            };
            return await _repository.AddStudentAsync(student);
        }
    }
}