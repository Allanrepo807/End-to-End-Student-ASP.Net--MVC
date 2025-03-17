namespace WApp.Application.DTO
{
    public class SubjectResultWithAvgDto
    {
        public IEnumerable<SubjectResultDto> SubjectResults { get; set; }
        public decimal AverageMarks { get; set; }
    }
}
