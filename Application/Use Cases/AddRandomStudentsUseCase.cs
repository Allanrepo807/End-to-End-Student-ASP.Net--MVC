using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Application.DTOs;

namespace WApp.Application.UseCases
{
    public class AddRandomStudentsUseCase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectResultRepository _subjectResultRepository;
        private readonly IResultRepository _resultRepository;
        private readonly IYearlyGpaRepository _yearlyGpaRepository;
        private readonly ISubjectRepository _subjectRepository;

        public AddRandomStudentsUseCase(
            IStudentRepository studentRepository,
            ISubjectResultRepository subjectResultRepository,
            IResultRepository resultRepository,
            IYearlyGpaRepository yearlyGpaRepository,
            ISubjectRepository subjectRepository)
        {
            _studentRepository = studentRepository;
            _subjectResultRepository = subjectResultRepository;
            _resultRepository = resultRepository;
            _yearlyGpaRepository = yearlyGpaRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<StudentDto>> Execute(int count, int streamId, int year)
        {
            // Limit the number of fake students to generate
            count = Math.Min(count, 50);

            // Get all subjects for the specified stream and year
            var subjects = await _subjectRepository.GetSubjectsByStreamAndYearAsync(streamId, year);

            List<StudentDto> addedStudents = new List<StudentDto>();

            // Generate fake students
            var faker = new Faker();

            for (int i = 0; i < count; i++)
            {
                // 1. Create and add a random student
                var gender = faker.PickRandom<string>(new[] { "M", "F" });
                var student = new Student
                {
                    ID = Guid.NewGuid(),
                    Name = faker.Name.FullName(),
                    Gender = gender,
                    StreamId = streamId,
                    Year = year
                };

                var addedStudent = await _studentRepository.AddStudentAsync(student);

                // 2. Generate and add subject results for this student
                var subjectResults = new List<SubjectResult>();
                double totalMarks = 0;

                foreach (var subject in subjects)
                {
                    // Generate a random mark between 40 and 100
                    double mark = Math.Round(faker.Random.Double(40, 100), 2);
                    totalMarks += mark;

                    var subjectResult = new SubjectResult
                    {
                        SubId = subject.SubId,
                        StreamId = streamId,
                        StudentId = student.ID,
                        MarksObtained = mark
                    };

                    subjectResults.Add(subjectResult);
                }

                // Add all subject results
                await _subjectResultRepository.AddSubjectResultsAsync(subjectResults);

                // 3. Calculate and add the result (total marks and pass/fail)
                var result = new Result
                {
                    StudentId = student.ID,
                    Year = year,
                    TotalMarksObtained = totalMarks,
                    PassFail = totalMarks >= (subjects.Count() * 40) // Pass if average is at least 40
                };

                await _resultRepository.AddResultAsync(result);

                // 4. Calculate and add the yearly GPA
                // Converting total marks to GPA (assuming 500 is maximum possible marks for 5 subjects)
                double maxPossibleMarks = subjects.Count() * 100;
                double gpa = (totalMarks / maxPossibleMarks) * 4.0; // Assuming 4.0 scale

                var yearlyGpa = new YearlyGpa
                {
                    StudentId = student.ID,
                    Year = year,
                    YGpa = Math.Round(gpa, 2)
                };

                await _yearlyGpaRepository.AddYearlyGpaAsync(yearlyGpa);

                // Add to our result list
                addedStudents.Add(new StudentDto
                {
                    ID = student.ID,
                    Name = student.Name,
                    Gender = student.Gender,
                    StreamId = student.StreamId,
                    StreamName = student.Stream?.Name,
                    Year = student.Year
                });
            }

            return addedStudents;
        }
    }
}