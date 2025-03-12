namespace WApp.Domain.Models
{
    public class Student
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int StreamId { get; set; }

        public int Year { get; set; }

        // Navigation properties
        public Stream Stream { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<SubjectResult> SubjectResults { get; set; }
        public ICollection<YearlyGpa> YearlyGpas { get; set; }
    }
}