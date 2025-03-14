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

        public async Task<ResultWithAverageDto> GetResultByStudentAndYearAsync(string stream, int? year, string gender)
        {
            _logger.LogInformation($"Fetching result for students with specified parameters");
            var (results, avgmarks) = await _getResultsUseCase.Execute(stream, year, gender);

            return new ResultWithAverageDto
            {
                Results = results,
                AverageMarks = avgmarks
            };
        }
    }
}