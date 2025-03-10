namespace WApp.Domain.Models
{
    public class StreamSubject
    {
        public int StreamId { get; set; }
        public int SubjectId { get; set; }

        // Navigation properties
        public Stream Stream { get; set; }
        public Subject Subject { get; set; }
    }
}