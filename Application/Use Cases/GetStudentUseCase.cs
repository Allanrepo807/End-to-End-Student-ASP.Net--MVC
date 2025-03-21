﻿using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using WApp.Application.DTOs;

namespace WApp.Application.UseCases
{
    public class GetStudentUseCase
    {
        private readonly IStudentRepository _repository;

        public GetStudentUseCase(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentDto> Execute(Guid id)
        {
            var student = await _repository.GetStudentAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID: {id} not found");
            }
            return student;
        }
    }
}