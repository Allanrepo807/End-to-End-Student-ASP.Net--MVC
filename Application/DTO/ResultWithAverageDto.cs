using WApp.Application.DTO;

namespace WApp.Services
{
    public class ResultWithAverageDto
    {
        public IEnumerable<ResultDto> Results { get; set; }
        public double AverageMarks { get; set; }
    }
}