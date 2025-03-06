using WApp.Domain.Interfaces;
using WApp.Domain.Models;

namespace WApp.Application.UseCases
{
    public class GetStudentsUseCase
    {
        private readonly IStudentRepository _repository;

        public GetStudentsUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> Execute()
        {
            return await _repository.GetStudentsAsync();
        }
    }
}