using WApp.Application.UseCases; // Add this directive
using WApp.Domain.Models;

namespace WApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly GetStudentsUseCase _getStudentsUseCase;
        private readonly GetStudentUseCase _getStudentUseCase;
        private readonly AddStudentUseCase _addStudentUseCase;
        private readonly UpdateStudentUseCase _updateStudentUseCase;
        private readonly DeleteStudentUseCase _deleteStudentUseCase;
        private readonly DeleteAllStudentsUseCase _deleteAllStudentsUseCase;
        private readonly ILogger<StudentService> _logger;

        public StudentService(
            GetStudentsUseCase getStudentsUseCase,
            GetStudentUseCase getStudentUseCase,
            AddStudentUseCase addStudentUseCase,
            UpdateStudentUseCase updateStudentUseCase,
            DeleteStudentUseCase deleteStudentUseCase,
            DeleteAllStudentsUseCase deleteAllStudentsUseCase,
            ILogger<StudentService> logger)
        {
            _getStudentsUseCase = getStudentsUseCase;
            _getStudentUseCase = getStudentUseCase;
            _addStudentUseCase = addStudentUseCase;
            _updateStudentUseCase = updateStudentUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
            _deleteAllStudentsUseCase = deleteAllStudentsUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _getStudentsUseCase.Execute();
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            _logger.LogInformation($"Fetching student with ID: {id}");
            return await _getStudentUseCase.Execute(id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _logger.LogInformation("Adding a new student");
            return await _addStudentUseCase.Execute(student);
        }

        public async Task UpdateStudentAsync(Guid id, Student student)
        {
            _logger.LogInformation($"Updating student with ID: {id}");
            await _updateStudentUseCase.Execute(id, student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            _logger.LogInformation($"Deleting student with ID: {id}");
            await _deleteStudentUseCase.Execute(id);
        }

        public async Task DeleteAllStudentsAsync()
        {
            _logger.LogInformation("Deleting all students.");
            await _deleteAllStudentsUseCase.Execute();
        }
    }
}