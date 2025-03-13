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

        public async Task<IEnumerable<ResultDto>> GetAllResultsAsync()
        {
            return await _context.Results
                .Include(r => r.Student)
                .Select(r => new ResultDto
                {
                    StudentId = r.StudentId,
                    Year = r.Year,
                    TotalMarksObtained = r.TotalMarksObtained,
                    PassFail = r.PassFail,
                    StudentName = r.Student.Name
                })
                .ToListAsync();
        }

        public async Task<ResultDto> GetResultByStudentAndYearAsync(Guid studentId, int year)
        {
            return await _context.Results
                .Include(r => r.Student)
                .Where(r => r.StudentId == studentId && r.Year == year)
                .Select(r => new ResultDto
                {
                    StudentId = r.StudentId,
                    Year = r.Year,
                    TotalMarksObtained = r.TotalMarksObtained,
                    PassFail = r.PassFail,
                    StudentName = r.Student.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
