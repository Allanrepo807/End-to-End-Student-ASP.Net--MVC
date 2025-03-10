namespace WApp.Domain.Models
{
    public class YearlyGpa
    {
        public Guid YearlyGPAId { get; set; } // Primary Key
        public Guid StudentId { get; set; } // Foreign Key to Student
        public int Year { get; set; } // Year of study (1, 2, 3, 4)
        public double GPA { get; set; } // GPA for the year
        public Student Student { get; set; } // Navigation to Student
    }
}
