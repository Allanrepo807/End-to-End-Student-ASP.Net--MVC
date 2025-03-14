
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Application.DTO;

using WApp.Services;

namespace WApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubjectResultController : ControllerBase
    {
        private readonly ISubjectResultService _subjectResultService;

        public SubjectResultController(ISubjectResultService subjectResultService)
        {
            _subjectResultService = subjectResultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResultDto>>> GetSubjectResults()
        {
            var subjectResults = await _subjectResultService.GetSubjectResultsAsync();
            return Ok(subjectResults);
        }

        [HttpGet("SubName/{subname}")]
        public async Task<ActionResult<IEnumerable<SubjectResultDto>>> GetSubjectResultsByStudent(string subname)
        {
            var subjectResults = await _subjectResultService.GetSubjectResultsByStudentIdAsync(subname);
            return Ok(subjectResults);
        }
    }
}