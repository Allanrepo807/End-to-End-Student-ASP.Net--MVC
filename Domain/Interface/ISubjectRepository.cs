using WApp.Domain.Models;
using WApp.Application.DTO;

namespace WApp.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsByStreamAndYearAsync(int streamId, int year);
        Task<IEnumerable<SubjectDto>> GetSubjectAsync(int streamId, int year);

        // Add other methods as needed
    }
}