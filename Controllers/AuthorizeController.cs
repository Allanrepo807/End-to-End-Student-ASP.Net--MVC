using Microsoft.AspNetCore.Mvc;
using WApp.Services;
using WApp.Domain.Models;
namespace WApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserService _userService; // Need to add this service

        public AuthController(TokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Username and password are required");

            // Check if user already exists
            var existingUser = await _userService.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
                return BadRequest("Username already exists");

            // Create new user (with hashed password)
            var result = await _userService.CreateUserAsync(request.Username, request.Password);
            if (!result)
                return StatusCode(500, "Failed to create user");

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Validate the user credentials
            var user = await _userService.ValidateUserAsync(request.Username, request.Password);
            if (user == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            // Generate JWT token
            var token = _tokenService.GenerateToken(user.Username);
            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}