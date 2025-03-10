namespace WApp.Domain.Models
{
    public class Student

    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int Sid { get; set; }

        public string Stream { get; set; }
        
        public double Gpa { get; set; }

        public ICollection<Result> Results { get; set; }



    }

}
