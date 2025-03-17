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

        public async Task<(IEnumerable<SubjectResultDto >Subject_Results, decimal avg)> GetSubjectResultsByStudentIdAsync(string subname)
        {
                 var subject_result = await _context.SubjectResults
                .Include(sr => sr.Subject)
                .Include(sr => sr.Student)
                .Where(sr => sr.Subject.SubName == subname)
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

            var avg = subject_result.Any() ?(decimal) Math.Round(subject_result.Average(sr => sr.MarksObtained), 2) : 0;

            return (subject_result, avg);
        }
    }
}