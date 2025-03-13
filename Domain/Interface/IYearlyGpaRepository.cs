using System;
using System.Threading.Tasks;
using WApp.Application.DTO;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IYearlyGpaRepository
    {
        Task<YearlyGpa> AddYearlyGpaAsync(YearlyGpa yearlyGpa);
        Task<IEnumerable<YearlyGpaDto>> GetAllYearlyGpasAsync();
        Task<YearlyGpaDto> GetYearlyGpaByStudentAndYearAsync(Guid studentId, int year);
        // Add other methods as needed
    }
}