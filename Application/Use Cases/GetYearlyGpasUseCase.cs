using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WApp.Application.DTO;
using WApp.Application.DTOs;
using WApp.Domain.Interfaces;

namespace WApp.Application.UseCases
{
    public class GetYearlyGpasUseCase
    {
        private readonly IYearlyGpaRepository _repository;

        public GetYearlyGpasUseCase(IYearlyGpaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<YearlyGpaDto>> Execute()
        {
            return await _repository.GetAllYearlyGpasAsync();
        }

        public async Task<YearlyGpaDto> Execute(Guid studentId, int year)
        {
            return await _repository.GetYearlyGpaByStudentAndYearAsync(studentId, year);
        }
    }
}