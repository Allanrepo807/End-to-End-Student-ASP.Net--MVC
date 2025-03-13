using WApp.Application.DTO;

namespace WApp.Services
{
    public interface IResultService
    {
        Task<IEnumerable<ResultDto>> GetResultsAsync();
        Task<ResultDto> GetResultByStudentAndYearAsync(Guid studentId, int year);
    }
}