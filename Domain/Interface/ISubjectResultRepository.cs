using WApp.Application.DTO;
using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface ISubjectResultRepository
    {
        Task AddSubjectResultsAsync(IEnumerable<SubjectResult> subjectResults);
        Task<IEnumerable<SubjectResultDto>> GetAllSubjectResultsAsync();
        Task<IEnumerable<SubjectResultDto>> GetSubjectResultsByStudentIdAsync(string subaname);
        // Add other methods as needed
    }
}