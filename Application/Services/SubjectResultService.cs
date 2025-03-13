using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WApp.Application.DTO;
using WApp.Application.DTOs;
using WApp.Application.UseCases;

namespace WApp.Services
{   public class SubjectResultService : ISubjectResultService
    {
        private readonly GetSubjectResultsUseCase _getSubjectResultsUseCase;
        private readonly ILogger<SubjectResultService> _logger;

        public SubjectResultService(
            GetSubjectResultsUseCase getSubjectResultsUseCase,
            ILogger<SubjectResultService> logger)
        {
            _getSubjectResultsUseCase = getSubjectResultsUseCase;
            _logger = logger;
        }

        public async Task<IEnumerable<SubjectResultDto>> GetSubjectResultsAsync()
        {
            _logger.LogInformation("Fetching all subject results");
            return await _getSubjectResultsUseCase.Execute();
        }

        public async Task<IEnumerable<SubjectResultDto>> GetSubjectResultsByStudentIdAsync(Guid studentId)
        {
            _logger.LogInformation($"Fetching subject results for student: {studentId}");
            return await _getSubjectResultsUseCase.Execute(studentId);
        }
    }
}