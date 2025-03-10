namespace WApp.Domain.Models
{
    public class Stream
    {
        public int StreamId { get; set; } // Primary Key (matches Sid in Student table)
        public string StreamName { get; set; } // Stream name matches the stream name in the student table

        // Initialize the collection in constructor
        public Stream()
        {
            StreamSubjects = new List<StreamSubject>();
        }

        // Navigation property for the many-to-many relationship with Subject
        public ICollection<StreamSubject> StreamSubjects { get; set; }

    }
}
