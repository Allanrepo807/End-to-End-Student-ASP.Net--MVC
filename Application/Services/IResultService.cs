

namespace WApp.Services
{
    public interface IResultService
    {
        Task<ResultWithAverageDto> GetResultByStudentAndYearAsync(string stream, int year, string gender, string subname);
    }
}