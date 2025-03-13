
using Microsoft.EntityFrameworkCore;
using WApp.Application.DTO;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;

namespace WApp.Infrastructure.Repositories
{
    public class SubjectResultRepository : ISubjectResultRepository
    {
        private readonly StudentContext _context;

        public SubjectResultRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task AddSubjectResultsAsync(IEnumerable<SubjectResult> subjectResults)
        {
            await _context.SubjectResults.AddRangeAsync(subjectResults);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubjectResultDto>> GetAllSubjectResultsAsync()
        {
            return await _context.SubjectResults
                .Include(sr => sr.Subject)
                .Include(sr => sr.Student)
                .Select(sr => new SubjectResultDto
                {
                    SubId = sr.SubId,
                    StreamId = sr.StreamId,
                    StudentId = sr.StudentId,
                    MarksObtained = sr.MarksObtained,
                    SubjectName = sr.Subject.SubName,
                    StudentName = sr.Student.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SubjectResultDto>> GetSubjectResultsByStudentIdAsync(Guid studentId)
        {
            return await _context.SubjectResults
                .Include(sr => sr.Subject)
                .Include(sr => sr.Student)
                .Where(sr => sr.StudentId == studentId)
                .Select(sr => new SubjectResultDto
                {
                    SubId = sr.SubId,
                    StreamId = sr.StreamId,
                    StudentId = sr.StudentId,
                    MarksObtained = sr.MarksObtained,
                    SubjectName = sr.Subject.SubName,
                    StudentName = sr.Student.Name
                })
                .ToListAsync();
        }
    }
}