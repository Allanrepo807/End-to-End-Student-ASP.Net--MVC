using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Application.DTO;
using WApp.Services;

namespace WApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultDto>>> GetResults()
        {
            var results = await _resultService.GetResultsAsync();
            return Ok(results);
        }

        [HttpGet("student/{studentId}/year/{year}")]
        public async Task<ActionResult<ResultDto>> GetResultByStudentAndYear(Guid studentId, int year)
        {
            var result = await _resultService.GetResultByStudentAndYearAsync(studentId, year);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}