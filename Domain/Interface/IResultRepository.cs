using System;
using System.Threading.Tasks;
using WApp.Application.DTO;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> AddResultAsync(Result result);
        Task<IEnumerable<ResultDto>> GetAllResultsAsync();
        Task<ResultDto> GetResultByStudentAndYearAsync(Guid studentId, int year);
        // Add other methods as needed
    }
}