using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WApp.Domain.Models;
using System.Linq;
using WApp.Data;

namespace WApp.Filters
{
    public class StudentValidationFilter : IActionFilter
    {
        private readonly StudentContext _context;

        public StudentValidationFilter(StudentContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("student", out var studentObj)
                && studentObj is Student student)
            {
                // Check if this is a POST request (creating a new student)
                var isPostRequest = context.HttpContext.Request.Method == "POST";

                // If the ID is empty or default AND this is a POST request, DON'T generate a GUID
                // Let the database handle it through HasDefaultValueSql("NEWID()")
                if (student.ID == Guid.Empty && isPostRequest)
                {
                    // Don't generate a GUID here - let the database do it
                }

                // Validate the Name property
                var validationErrors = ValidateStudent(student);
                if (validationErrors.Any())
                {
                    // If validation fails, return a BadRequest response with validation errors
                    context.Result = new BadRequestObjectResult(validationErrors);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after execution
        }

        private static string[] ValidateStudent(Student student)
        {
            var errors = new System.Collections.Generic.List<string>();
            // Validate Name
            if (string.IsNullOrEmpty(student.Name))
            {
                errors.Add("Name is required.");
            }
            else if (student.Name.Length > 50)
            {
                errors.Add("Name cannot exceed 50 characters.");
            }
            return errors.ToArray();
        }
    }
}