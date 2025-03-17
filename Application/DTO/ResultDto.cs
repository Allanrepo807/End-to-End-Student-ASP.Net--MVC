using System.Text.Json.Serialization;

namespace WApp.Application.DTO
{
    public class ResultDto
    {
        public Guid StudentId { get; set; }
        public int Year { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalMarksObtained { get; set; } // Nullable double

        public string StudentName { get; set; }
        public string StreamName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SubjectName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double MarksObtained { get; set; } // Use WhenWritingDefault for value types
    }
}