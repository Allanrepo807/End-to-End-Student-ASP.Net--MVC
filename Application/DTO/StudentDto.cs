namespace WApp.Application.DTOs
{
    public class StudentDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int StreamId { get; set; }

        public int Year { get; set; }

        public string StreamName { get; set; }
    }
}
