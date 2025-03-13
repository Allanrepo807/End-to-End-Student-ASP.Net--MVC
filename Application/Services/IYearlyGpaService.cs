
using WApp.Application.DTO;


namespace WApp.Services
{
    public interface IYearlyGpaService
    {
        Task<IEnumerable<YearlyGpaDto>> GetYearlyGpasAsync();
        Task<YearlyGpaDto> GetYearlyGpaByStudentAndYearAsync(Guid studentId, int year);
    }

    
}