using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsByStreamAndYearAsync(int streamId, int year);
        // Add other methods as needed
    }
}