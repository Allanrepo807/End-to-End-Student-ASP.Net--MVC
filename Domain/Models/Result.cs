using WApp.Domain.Models;

public class Result
{
    // Composite primary key
    public Guid StudentId { get; set; }
    public int Year { get; set; }

    // Total marks across all subjects
    public double TotalMarksObtained { get; set; }

    // Navigation property
    public Student Student { get; set; }

    // Remove these properties
    // public string SubjectSubId { get; set; }
    // public int SubjectStreamId { get; set; }
    // public Subject Subject { get; set; }
}