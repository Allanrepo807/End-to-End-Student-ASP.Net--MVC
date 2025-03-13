using WApp.Application.DTO;
using WApp.Domain.Interfaces;
namespace WApp.Application.UseCases
{
    public class GetResultsUseCase
    {
        private readonly IResultRepository _repository;

        public GetResultsUseCase(IResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResultDto>> Execute()
        {
            return await _repository.GetAllResultsAsync();
        }

        public async Task<ResultDto> Execute(Guid studentId, int year)
        {
            return await _repository.GetResultByStudentAndYearAsync(studentId, year);
        }
    }
}