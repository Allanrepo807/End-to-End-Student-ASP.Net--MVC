

namespace WApp.Domain.Models
{
    public class Stream
    {
        public int StreamId { get; set; } // Primary key
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}