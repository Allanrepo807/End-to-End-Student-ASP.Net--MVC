using WApp.Application.UseCases; // Add this directive
using WApp.Domain.Models;
using WApp.Application.DTOs;
using WApp.Application.DTO;
using WApp.Application.Use_Cases;

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
        private readonly AddRandomStudentsUseCase _addRandomStudentsUseCase;
        private readonly GetSubjectUseCase _getSubjectUseCase;
        private readonly ILogger<StudentService> _logger;

        public StudentService(
            GetStudentsUseCase getStudentsUseCase,
            GetStudentUseCase getStudentUseCase,
            AddStudentUseCase addStudentUseCase,
            UpdateStudentUseCase updateStudentUseCase,
            DeleteStudentUseCase deleteStudentUseCase,
            DeleteAllStudentsUseCase deleteAllStudentsUseCase,
            AddRandomStudentsUseCase addRandomStudentsUseCase,// Inject the new use case
            GetSubjectUseCase getSubjectUseCase,
            ILogger<StudentService> logger)
        {
            _getStudentsUseCase = getStudentsUseCase;
            _getStudentUseCase = getStudentUseCase;
            _addStudentUseCase = addStudentUseCase;
            _updateStudentUseCase = updateStudentUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
            _deleteAllStudentsUseCase = deleteAllStudentsUseCase;
            _addRandomStudentsUseCase = addRandomStudentsUseCase;
            _getSubjectUseCase = getSubjectUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _getStudentsUseCase.Execute();
        }

        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            _logger.LogInformation($"Fetching student with ID: {id}");
            return await _getStudentUseCase.Execute(id);
        }

        public async Task<Student> AddStudentAsync(AddStudentDto studentdto)
        {
            _logger.LogInformation("Adding a new student");
            return await _addStudentUseCase.Execute(studentdto);
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
        public async Task<IEnumerable<StudentDto>> AddRandomStudentsAsync(int count, int streamId, int year)
        {
            _logger.LogInformation($"Generating {count} random students for stream {streamId} and year {year}");
            return await _addRandomStudentsUseCase.Execute(count, streamId, year);
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjects(int stream, int year)
        {
            _logger.LogInformation($" Returning subject with stream:{stream} and year:{year}");
            return await _getSubjectUseCase.Execute(stream, year);
        }
    }
}