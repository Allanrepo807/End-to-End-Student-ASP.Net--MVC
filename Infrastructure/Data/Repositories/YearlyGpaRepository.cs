using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WApp.Application.DTO;
using WApp.Application.DTOs;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;

namespace WApp.Infrastructure.Repositories
{
    public class YearlyGpaRepository : IYearlyGpaRepository
    {
        private readonly StudentContext _context;

        public YearlyGpaRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<YearlyGpa> AddYearlyGpaAsync(YearlyGpa yearlyGpa)
        {
            await _context.YearlyGpas.AddAsync(yearlyGpa);
            await _context.SaveChangesAsync();
            return yearlyGpa;
        }

        public async Task<IEnumerable<YearlyGpaDto>> GetAllYearlyGpasAsync()
        {
            return await _context.YearlyGpas
                .Include(yg => yg.Student)
                .Select(yg => new YearlyGpaDto
                {
                    StudentId = yg.StudentId,
                    Year = yg.Year,
                    YGpa = yg.YGpa,
                    StudentName = yg.Student.Name
                })
                .ToListAsync();
        }

        public async Task<YearlyGpaDto> GetYearlyGpaByStudentAndYearAsync(Guid studentId, int year)
        {
            return await _context.YearlyGpas
                .Include(yg => yg.Student)
                .Where(yg => yg.StudentId == studentId && yg.Year == year)
                .Select(yg => new YearlyGpaDto
                {
                    StudentId = yg.StudentId,
                    Year = yg.Year,
                    YGpa = yg.YGpa,
                    StudentName = yg.Student.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}