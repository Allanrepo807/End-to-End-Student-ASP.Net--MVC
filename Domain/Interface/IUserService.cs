namespace WApp.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> CreateUserAsync(string username, string password);
        Task<User> ValidateUserAsync(string username, string password);
    }
}