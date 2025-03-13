
using WApp.Application.DTO;
using WApp.Application.UseCases;

namespace WApp.Services
{

    public class YearlyGpaService : IYearlyGpaService
    {
        private readonly GetYearlyGpasUseCase _getYearlyGpasUseCase;
        private readonly ILogger<YearlyGpaService> _logger;

        public YearlyGpaService(
            GetYearlyGpasUseCase getYearlyGpasUseCase,
            ILogger<YearlyGpaService> logger)
        {
            _getYearlyGpasUseCase = getYearlyGpasUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<YearlyGpaDto>> GetYearlyGpasAsync()
        {
            _logger.LogInformation("Fetching all yearly GPAs");
            return await _getYearlyGpasUseCase.Execute();
        }

        public async Task<YearlyGpaDto> GetYearlyGpaByStudentAndYearAsync(Guid studentId, int year)
        {
            _logger.LogInformation($"Fetching yearly GPA for student: {studentId}, year: {year}");
            return await _getYearlyGpasUseCase.Execute(studentId, year);
        }
    }
}