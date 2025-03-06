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
        private static readonly Guid DefaultSwaggerGuid = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");

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

                if (isPostRequest && student.ID == DefaultSwaggerGuid)
                {
                    student.ID = Guid.Empty;
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