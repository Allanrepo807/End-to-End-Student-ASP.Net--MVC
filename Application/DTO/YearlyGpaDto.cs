namespace WApp.Application.DTO
{
    public class YearlyGpaDto
    {
        public Guid StudentId { get; set; }
        public int Year { get; set; }
        public double YGpa { get; set; }
        public string StudentName { get; set; }
    }
}
