using Marketplace.Data;
using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
using Marketplace.Enums;
using Marketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public UserController(UserManager<ApplicationUser> userManager, DataContext context, TokenService tokenService)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var User = new ApplicationUser { UserName = request.Username, Email = request.Email, Role = request.Role };

            var result = await _userManager.CreateAsync(
                User,
                request.Password!
            );

            if (result.Succeeded)
            {
                request.Password = "";
                var accessToken = _tokenService.CreateToken(User);

                // Include the access token in the response
                var response = new
                {
                    Id = User.Id,
                    Email = request.Email,
                    Username = request.Username,
                    Role = request.Role,
                    AccessToken = accessToken
                };

                return CreatedAtAction(nameof(Register), response);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);


            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Id = userInDb.Id,
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.UserName,
                    u.Email,
                    u.Role
                })
                .ToListAsync();

            var userResponses = users.Select(u => new UserResponse
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email,
                Role = u.Role
            }).ToList();

            return Ok(userResponses);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("users/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent(); // 204 No Content if deletion is successful
            }

            // If deletion failed, return the errors
            return BadRequest(result.Errors);
        }
    }

    // Define a response model for user data
    public class UserResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}

