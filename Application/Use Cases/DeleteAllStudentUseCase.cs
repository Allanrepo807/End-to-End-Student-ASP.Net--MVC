using WApp.Domain.Interfaces;

namespace WApp.Application.UseCases
{
    public class DeleteAllStudentsUseCase
    {
        private readonly IStudentRepository _repository;

        public DeleteAllStudentsUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute()
        {
            var students = await _repository.GetStudentsAsync();
            await _repository.DeleteAllStudentsAsync();
        }
    }
}