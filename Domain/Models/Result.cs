namespace WApp.Domain.Models
{
    public class Result
    {
        // Composite primary key (StudentId + Year)
        public Guid StudentId { get; set; }
        public int Year { get; set; }

        public double TotalMarksObtained { get; set; }
        public bool PassFail { get; set; }

        // Navigation property
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}