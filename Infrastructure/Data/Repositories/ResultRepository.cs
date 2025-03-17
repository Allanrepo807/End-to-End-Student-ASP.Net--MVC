using Microsoft.EntityFrameworkCore;
using WApp.Application.DTO;
using WApp.Domain.Interfaces;
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
        public async Task<(IEnumerable<ResultDto> Results, double AverageMarks)> GetResultByStudentAndYearAsync(
    string stream, int? year, string gender, List<string> subnames = null)
        {
            // If subnames is provided and not empty, call the GetSubjectResultsByFiltersAsync method
            if (subnames != null && subnames.Any())
            {
                var (subjectResults, avgMarks) = await GetSubjectResultsByFiltersAsync(stream, year, gender, subnames);

                // Convert SubjectResultDto to ResultDto
                var resultDtos = subjectResults.Select(sr => new ResultDto
                {
                    StudentId = sr.StudentId,
                    Year = sr.Year,
                    StudentName = sr.StudentName,
                    StreamName = sr.StreamName,
                    SubjectName = sr.SubjectName,
                    MarksObtained = sr.MarksObtained
                });

                // Convert decimal to double
                return (Results: resultDtos, AverageMarks: (double)avgMarks);
            }

            // Original implementation when subnames is null or empty
            var query = _context.Results
                .Include(r => r.Student)
                    .ThenInclude(s => s.Stream)
                .AsQueryable();

            if (!string.IsNullOrEmpty(stream))
            {
                query = query.Where(r => r.Student.Stream.Name == stream);
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(r => r.Student.Gender == gender);
            }

            if (year.HasValue && year > 0)
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
                    StreamName = r.Student.Stream.Name
                })
                .ToListAsync();

            var avgmarks = results.Any() ? Math.Round((double)results.Average(r => r.TotalMarksObtained), 2) : 0;
            return (Results: results, AverageMarks: avgmarks);
        }

        // Method to get subject results with multiple filters and multiple subject names
        public async Task<(IEnumerable<SubjectResultDto> Subject_Results, decimal avg)> GetSubjectResultsByFiltersAsync(
            string stream, int? year, string gender, List<string> subnames)
        {
            var query = _context.SubjectResults
                .Include(sr => sr.Subject)
                .Include(sr => sr.Student)
                    .ThenInclude(s => s.Stream)
                .AsQueryable();

            // Filter by subject names
            if (subnames != null && subnames.Any())
            {
                query = query.Where(sr => subnames.Contains(sr.Subject.SubName));
            }

            if (!string.IsNullOrEmpty(stream))
            {
                query = query.Where(sr => sr.Student.Stream.Name == stream);
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(sr => sr.Student.Gender == gender);
            }

            if (year.HasValue && year > 0)
            {
                query = query.Where(sr => sr.Subject.Year == year);
            }

            var subject_results = await query
                .Select(sr => new SubjectResultDto
                {
                    SubId = sr.SubId,
                    StreamId = sr.StreamId,
                    StudentId = sr.StudentId,
                    MarksObtained = sr.MarksObtained,
                    SubjectName = sr.Subject.SubName,
                    StudentName = sr.Student.Name,
                    StreamName = sr.Student.Stream.Name,
                    Year = sr.Subject.Year
                })
                .ToListAsync();

            var avg = subject_results.Any() ? (decimal)Math.Round(subject_results.Average(sr => sr.MarksObtained), 2) : 0;
            return (subject_results, avg);
        }




    }



}
