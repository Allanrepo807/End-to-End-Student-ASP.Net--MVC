using System;
using System.Threading.Tasks;
using WApp.Application.DTO;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> AddResultAsync(Result result);
        Task<(IEnumerable<ResultDto> Results, double AverageMarks)> GetResultByStudentAndYearAsync(string stream, int year, string gender, string subname);
    }
}