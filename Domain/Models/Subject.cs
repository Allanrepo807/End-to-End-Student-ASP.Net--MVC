namespace WApp.Domain.Models
{
    public class Subject
    {
        public int SubjectId { get; set; } // Primary Key
        public string SubjectName { get; set; }
        public int Year { get; set; } // Year of study (1, 2, 3, 4)

        // Initialize the collections in constructor
        public Subject()
        {
            StreamSubjects = new List<StreamSubject>();
            Results = new List<Result>();
        }

        // Navigation property for many-to-many relationship with Stream
        public ICollection<StreamSubject> StreamSubjects { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}