using Microsoft.EntityFrameworkCore;
using WApp.Application.DTO;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;

namespace WApp.Infrastructure.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly StudentContext _context;

        public ResultRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<Result> AddResultAsync(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<(IEnumerable<ResultDto> Results ,double AverageMarks)> GetResultByStudentAndYearAsync(string stream, int year, string gender, string subname)
        {

            var query = _context.Results
                .Include(r => r.Subject)
                .Include(r=> r.Student)
                    .ThenInclude(s => s.Stream)
                .AsQueryable();

            if (!string.IsNullOrEmpty(stream))
            {
                query = query.Where(r => r.Student.Stream.Name == stream);
            }

            if(!string.IsNullOrEmpty(gender))
            {
                query = query.Where(r => r.Student.Gender == gender);
            }
            if (!string.IsNullOrEmpty(subname))
            {
                query = query.Where(r => r.Subject.SubName == subname);
            }
            if( year > 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var results = await query
                .Include(r => r.Student)
                .Select(r => new ResultDto
                {
                    StudentId = r.StudentId,
                    Year = r.Year,
                    TotalMarksObtained = r.TotalMarksObtained,
                    StudentName = r.Student.Name,
                    subname = r.Subject.SubName,
                    StreamName = r.Student.Stream.Name
                })
                .ToListAsync();

            var avgmarks = results.Any() ? results.Average(r => r.TotalMarksObtained) : 0;

            return (Results: results, AverageMarks: avgmarks);



        }

            
    }
}
