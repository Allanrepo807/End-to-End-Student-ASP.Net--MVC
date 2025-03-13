namespace WApp.Domain.Models
{
    public class Subject
    {
        public string SubId { get; set; }  // Part of composite key
        public int StreamId { get; set; }  // Part of composite key
        public string SubName { get; set; }
        public int Year { get; set; }

        // Navigation properties
        public Stream Stream { get; set; }
        public ICollection<SubjectResult> SubjectResults { get; set; }

        public ICollection<Result> Results { get; set; }


    }
}