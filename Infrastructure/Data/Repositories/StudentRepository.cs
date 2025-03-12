using Microsoft.EntityFrameworkCore;
using WApp.Application.DTOs;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;
using WApp.Application.DTOs;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository(StudentContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentAsync(Guid id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<Student> AddStudentAsync(AddStudentDto student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAllStudentsAsync()
    {
        var students = await _context.Students.ToListAsync();
        _context.Students.RemoveRange(students);
        await _context.SaveChangesAsync();
    }
}