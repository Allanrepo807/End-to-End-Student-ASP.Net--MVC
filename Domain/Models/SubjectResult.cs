namespace WApp.Domain.Models
{
    public class SubjectResult
    {
        public string SubId { get; set; }  // Foreign Key (part of composite key)
        public int StreamId { get; set; }  // Foreign Key (part of composite key)
        public Guid StudentId { get; set; }  // Foreign Key
        public double MarksObtained { get; set; }  // Added missing property

        // Navigation properties
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}