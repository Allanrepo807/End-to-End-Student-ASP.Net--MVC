

namespace WApp.Services
{
    public interface IResultService
    {
        Task<ResultWithAverageDto> GetResultByStudentAndYearAsync(string stream, int? year, string gender, List<string> subnames);
    }
}