using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Application.DTOs;

namespace WApp.Application.UseCases
{
    public class GetStudentsUseCase
    {
        private readonly IStudentRepository _repository;

        public GetStudentsUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<StudentDto>> Execute()
        {
            return await _repository.GetStudentsAsync();
        }
    }
}