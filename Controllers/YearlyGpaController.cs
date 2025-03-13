
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Application.DTO;

using WApp.Services;

namespace WApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class YearlyGpaController : ControllerBase
    {
        private readonly IYearlyGpaService _yearlyGpaService;

        public YearlyGpaController(IYearlyGpaService yearlyGpaService)
        {
            _yearlyGpaService = yearlyGpaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearlyGpaDto>>> GetYearlyGpas()
        {
            var yearlyGpas = await _yearlyGpaService.GetYearlyGpasAsync();
            return Ok(yearlyGpas);
        }

        [HttpGet("student/{studentId}/year/{year}")]
        public async Task<ActionResult<YearlyGpaDto>> GetYearlyGpaByStudentAndYear(Guid studentId, int year)
        {
            var yearlyGpa = await _yearlyGpaService.GetYearlyGpaByStudentAndYearAsync(studentId, year);
            if (yearlyGpa == null)
            {
                return NotFound();
            }
            return Ok(yearlyGpa);
        }
    }
}