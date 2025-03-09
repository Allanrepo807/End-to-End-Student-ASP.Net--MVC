using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WApp.Domain.Models;
using System.Linq;
using WApp.Infrastructure.Data;

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
                var isPostRequest = context.HttpContext.Request.Method == "POST";

                if (isPostRequest && student.ID == Guid.Empty)
                {
                    student.ID = Guid.NewGuid();
                }

                var validationErrors = ValidateStudent(student);
                if (validationErrors.Any())
                {
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