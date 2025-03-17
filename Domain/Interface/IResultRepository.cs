using WApp.Application.DTO;


namespace WApp.Domain.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> AddResultAsync(Result result);
        Task<(IEnumerable<ResultDto> Results, double AverageMarks)> GetResultByStudentAndYearAsync(string stream, int? year, string gender, List<string> subname);
    }
}