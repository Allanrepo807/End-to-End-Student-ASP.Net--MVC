﻿using WApp.Application.DTO;
using WApp.Domain.Interfaces;

namespace WApp.Application.UseCases
{
    public class GetResultsUseCase
    {
        private readonly IResultRepository _repository;

        public GetResultsUseCase(IResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<(IEnumerable<ResultDto> Results, double AverageMarks)> Execute(string stream, int? year, string gender)
        {
            return await _repository.GetResultByStudentAndYearAsync(stream, year, gender);
        }
    }
}