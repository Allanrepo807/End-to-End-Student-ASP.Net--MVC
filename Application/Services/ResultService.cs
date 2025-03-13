using WApp.Application.DTO;
using WApp.Application.UseCases;


namespace WApp.Services
{
    public class ResultService : IResultService
    {
        private readonly GetResultsUseCase _getResultsUseCase;
        private readonly ILogger<ResultService> _logger;

        public ResultService(
            GetResultsUseCase getResultsUseCase,
            ILogger<ResultService> logger)
        {
            _getResultsUseCase = getResultsUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<ResultDto>> GetResultsAsync()
        {
            _logger.LogInformation("Fetching all results");
            return await _getResultsUseCase.Execute();
        }

        public async Task<ResultDto> GetResultByStudentAndYearAsync(Guid studentId, int year)
        {
            _logger.LogInformation($"Fetching result for student: {studentId}, year: {year}");
            return await _getResultsUseCase.Execute(studentId, year);
        }
    }
}