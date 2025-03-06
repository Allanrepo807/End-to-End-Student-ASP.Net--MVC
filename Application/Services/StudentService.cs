using FluentValidation;
using WApp.Domain.Models;
using WApp.Models.Validators; // Assuming the validator is in this namespace

namespace WApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;
        private readonly StudentValidator _validator;

        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
            _validator = new StudentValidator();
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _repository.GetStudentsAsync();
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            _logger.LogInformation($"Fetching student with ID: {id}");
            var student = await _repository.GetStudentAsync(id);
            if (student == null)
            {
                _logger.LogWarning($"Student with ID: {id} not found");
                throw new KeyNotFoundException($"Student with ID: {id} not found");
            }
            return student;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            // Validate the student object
            var validationResult = _validator.Validate(student);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            _logger.LogInformation("Adding a new student");
            return await _repository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Guid id, Student student)
        {
            // Validate the student object
            var validationResult = _validator.Validate(student);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            if (id != student.ID)
            {
                _logger.LogWarning($"ID mismatch: {id} != {student.ID}");
                throw new ArgumentException("ID mismatch");
            }

            _logger.LogInformation($"Updating student with ID: {id}");
            await _repository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            _logger.LogInformation($"Deleting student with ID: {id}");
            await _repository.DeleteStudentAsync(id);
        }

        public async Task DeleteAllStudentsAsync()
        {
            _logger.LogInformation("Deleting all students.");
            await _repository.DeleteAllStudentsAsync();
        }
    }
}