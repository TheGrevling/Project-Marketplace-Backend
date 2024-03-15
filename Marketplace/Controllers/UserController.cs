﻿using Marketplace.Data;
using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
using Marketplace.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                    Email = request.Email,
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
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            });
        }
    }
}
