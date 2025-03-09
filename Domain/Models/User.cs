namespace WApp.Domain.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        // Add other user properties as needed
    }
}