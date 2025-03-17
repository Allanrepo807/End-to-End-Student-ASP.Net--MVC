using Microsoft.EntityFrameworkCore;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;
using WApp.Application.DTO;


namespace WApp.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentContext _context;

        public SubjectRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByStreamAndYearAsync(int streamId, int year)
        {
            return await _context.Subjects
                .Where(s => s.StreamId == streamId && s.Year == year)
                .ToListAsync();
        }
        public async Task<IEnumerable<SubjectDto>> GetSubjectAsync(int streamId, int year)
        {
            return await _context.Subjects
                .Where(s => s.StreamId == streamId && s.Year == year)
                .Select(s => new SubjectDto
                {
                    subID = s.SubId,
                    subName = s.SubName,
                    streamId = streamId,
                    year = year
                })
                .ToListAsync();
        }
    }
}