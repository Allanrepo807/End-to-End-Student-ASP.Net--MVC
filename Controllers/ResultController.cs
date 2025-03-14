using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ResultWithAverageDto>> GetResultByStudentAndYear(
        [FromQuery] string stream = null,
        [FromQuery] int? year = null,
        [FromQuery] string gender = null)
        {
            var result = await _resultService.GetResultByStudentAndYearAsync(stream, year, gender);
            if (result == null || !result.Results.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}