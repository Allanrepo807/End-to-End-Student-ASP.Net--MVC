using WApp.Application.DTO;


namespace WApp.Services
{
    public interface ISubjectResultService
    {
        Task<IEnumerable<SubjectResultDto>> GetSubjectResultsAsync();
        Task<SubjectResultWithAvgDto> GetSubjectResultsByStudentIdAsync(string subname);
        
    }
}