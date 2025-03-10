using WApp.Domain.Models;

namespace WApp.Domain.Models
{
    public class Result
    {

        public Guid ResultId { get; set; } // Primary Key
        public Guid StudentId { get; set; } // Foreign Key to Student
        public int SubjectId { get; set; } // Foreign Key to Subject
        public int Year { get; set; } // Year of study (1, 2, 3, 4)
        public double TotalMarksObtained { get; set; }
        
        public bool PassFail { get; set; }

        public Student Student { get; set; } // Navigation to Student
        public Subject Subject { get; set; } // Navigation to Subject

    }
}
