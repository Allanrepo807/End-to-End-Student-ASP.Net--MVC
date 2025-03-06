using WApp.Data;
using WApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _context;
        private readonly ILogger<StudentService> _logger;
        public StudentService(StudentContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            _logger.LogInformation($"Fetching student with ID: {id}");
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                _logger.LogWarning($"Student with ID: {id} not found");
                throw new KeyNotFoundException($"Student with ID: {id} not found");
            }

            return student;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _logger.LogInformation("Adding a new student");

            // Ensure a new GUID is generated
            student.ID = Guid.NewGuid();

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task UpdateStudentAsync(Guid id, Student student)
        {
            if (id != student.ID)
            {
                _logger.LogWarning($"ID mismatch: {id} != {student.ID}");
                throw new ArgumentException("ID mismatch");
            }

            _logger.LogInformation($"Updating student with ID: {id}");
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            _logger.LogInformation($"Deleting student with ID: {id}");
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                _logger.LogWarning($"Student with ID: {id} not found");
                throw new KeyNotFoundException($"Student with ID: {id} not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAllStudentsAsync()
        {
            _logger.LogInformation("Deleting all students.");
            var students = await _context.Students.ToListAsync();
            _context.Students.RemoveRange(students);
            await _context.SaveChangesAsync();
        }

    }
}
