namespace WApp.Application.DTO
{
    public class SubjectResultDto
    {
        public string SubId { get; set; }
        public int StreamId { get; set; }
        public Guid StudentId { get; set; }
        public double MarksObtained { get; set; }
        public string SubjectName { get; set; } // Added for display purposes
        public string StudentName { get; set; }
    }
}
