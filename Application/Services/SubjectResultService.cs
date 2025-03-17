using WApp.Application.DTO;
using WApp.Application.UseCases;

namespace WApp.Services
{   public class SubjectResultService : ISubjectResultService
    {
        private readonly GetSubjectResultsUseCase _getSubjectResultsUseCase;
        private readonly ILogger<SubjectResultService> _logger;

        public SubjectResultService(
            GetSubjectResultsUseCase getSubjectResultsUseCase,
            ILogger<SubjectResultService> logger)
        {
            _getSubjectResultsUseCase = getSubjectResultsUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<SubjectResultDto>> GetSubjectResultsAsync()
        {
            _logger.LogInformation("Fetching all subject results");
            return await _getSubjectResultsUseCase.Execute();
        }

        public async Task<SubjectResultWithAvgDto> GetSubjectResultsByStudentIdAsync(string subname)
        {
            _logger.LogInformation($"Fetching subject results for subname: {subname}");
            var (subjectResults, avg) = await _getSubjectResultsUseCase.Execute(subname);
            return new SubjectResultWithAvgDto
            {
                SubjectResults = subjectResults,
                AverageMarks = avg
            };
        }
    }
}