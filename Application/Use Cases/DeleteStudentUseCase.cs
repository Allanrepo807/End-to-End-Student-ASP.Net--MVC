using WApp.Domain.Interfaces;


namespace WApp.Application.UseCases
{
    public class DeleteStudentUseCase
    {
        private readonly IStudentRepository _repository;

        public DeleteStudentUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id)
        {
            await _repository.DeleteStudentAsync(id);
        }
    }
}