using WApp.Domain.Models;

namespace WApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<bool> CreateAsync(User user);
    }
}