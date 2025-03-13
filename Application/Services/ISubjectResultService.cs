using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WApp.Application.DTO;
using WApp.Application.DTOs;
using WApp.Application.UseCases;

namespace WApp.Services
{
    public interface ISubjectResultService
    {
        Task<IEnumerable<SubjectResultDto>> GetSubjectResultsAsync();
        Task<IEnumerable<SubjectResultDto>> GetSubjectResultsByStudentIdAsync(Guid studentId);
    }
}