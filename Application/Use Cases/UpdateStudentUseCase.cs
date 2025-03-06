using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace WApp.Application.UseCases
{
    public class UpdateStudentUseCase
    {
        private readonly IStudentRepository _repository;

        public UpdateStudentUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id, Student student)
        {
            if (id != student.ID)
            {
                throw new ArgumentException("ID mismatch");
            }
            await _repository.UpdateStudentAsync(student);
        }
    }
}