namespace WApp.Application.DTO
{
    public class ResultDto
    {
        public Guid StudentId { get; set; }
        public int Year { get; set; }
        public double TotalMarksObtained { get; set; }
        public bool PassFail { get; set; }
        public string StudentName { get; set; }
    }
}
