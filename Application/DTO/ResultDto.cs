namespace WApp.Application.DTO
{
    public class ResultDto
    {
        public Guid StudentId { get; set; }
        public int Year { get; set; }
        public double? TotalMarksObtained { get; set; } // Make nullable
        public string StudentName { get; set; }
        public string StreamName { get; set; }
        public string SubjectName { get; set; } // New property
        public double MarksObtained { get; set; } // New property


    }
}
