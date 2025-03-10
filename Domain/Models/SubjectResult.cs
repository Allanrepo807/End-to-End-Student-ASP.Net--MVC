namespace WApp.Domain.Models
{
    public class SubjectResult
    {
        public Guid SubjectResultId { get; set; } // Primary Key
        public Guid StudentId { get; set; } // Foreign Key to Student
        public int SubjectId { get; set; } // Foreign Key to Subject
        public int Year { get; set; } // Year of study (1, 2, 3, 4)
        public double MarksObtained { get; set; } // Marks obtained in the subject

        public Student Student { get; set; } // Navigation to Student
        public Subject Subject { get; set; } // Navigation to Subject
    }
}
