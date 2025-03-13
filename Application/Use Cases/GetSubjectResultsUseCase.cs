using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WApp.Application.DTO;
using WApp.Application.DTOs;
using WApp.Domain.Interfaces;

namespace WApp.Application.UseCases
{
    public class GetSubjectResultsUseCase
    {
        private readonly ISubjectResultRepository _repository;

        public GetSubjectResultsUseCase(ISubjectResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubjectResultDto>> Execute()
        {
            return await _repository.GetAllSubjectResultsAsync();
        }

        public async Task<IEnumerable<SubjectResultDto>> Execute(Guid studentId)
        {
            return await _repository.GetSubjectResultsByStudentIdAsync(studentId);
        }
    }
}