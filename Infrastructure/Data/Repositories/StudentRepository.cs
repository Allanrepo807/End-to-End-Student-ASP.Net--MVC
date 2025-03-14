﻿using Microsoft.EntityFrameworkCore;
using WApp.Application.DTOs;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Infrastructure.Data;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository(StudentContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
    {
        return await _context.Students
            .Include(s => s.Stream)
            .Select( s => new StudentDto
            {
               ID = s.ID,
               Name = s.Name,
               StreamId = s.StreamId,
               StreamName =s.Stream.Name,
               Gender = s.Gender,
               Year = s.Year
            })
            .ToListAsync();
    }

    public async Task<StudentDto?> GetStudentAsync(Guid id)
    {
        return await _context.Students
            .Include(s => s.Stream)
            .Where(s => s.ID == id)
            .Select(s => new StudentDto
            {
                ID = s.ID,
                Name = s.Name,
                StreamId = s.StreamId,
                StreamName = s.Stream.Name,
                Gender = s.Gender,
                Year = s.Year
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Student> AddStudentAsync(Student student)
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