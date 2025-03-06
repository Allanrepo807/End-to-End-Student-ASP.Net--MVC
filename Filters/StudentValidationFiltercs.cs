using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WApp.Domain.Models;

namespace WApp.Filters
{
    public class StudentValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("student", out var studentObj)
                && studentObj is Student student)
            {
                // If the ID is empty or default, generate a new GUID
                if (student.ID == Guid.Empty)
                {
                    student.ID = Guid.NewGuid();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after execution
        }
    }
}