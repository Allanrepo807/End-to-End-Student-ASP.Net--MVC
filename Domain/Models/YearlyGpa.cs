namespace WApp.Domain.Models
{
    public class YearlyGpa
    {
        // Composite primary key (StudentId + Year)
        public Guid StudentId { get; set; }
        public int Year { get; set; }

        public double YGpa { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }

}
