using WApp.Domain.Interfaces;
using WApp.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace WApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<bool> CreateUserAsync(string username, string password)
        {
            // Hash the password before storing
            var hashedPassword = HashPassword(password);
            var user = new User
            {
                ID = Guid.NewGuid(),
                Username = username,
                PasswordHash = hashedPassword
            };

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
                return null;

            // Verify the password
            var hashedPassword = HashPassword(password);
            if (user.PasswordHash != hashedPassword)
                return null;

            return user;
        }

        private string HashPassword(string password)
        {
            // In a real application, use a proper password hashing library like BCrypt
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}