using API.UserDtos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        public AccountsController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _signInManager.UserManager.CreateAsync(user, registerDto.Password!);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent:false);
                return Ok(new UserDto
                {
                    FirstName = user.FirstName!,
                    LastName = user.LastName!,
                    Email = user.Email!,
                    Role = "User"
                });
            }

            foreach(var err in result.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }

            return ValidationProblem();
        }


        [AllowAnonymous]
        [HttpGet("user-info")]
        public async Task<IActionResult> GetUserInfo()
        {
            if(User.Identity?.IsAuthenticated == false) return Unauthorized();
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if(user == null) return Unauthorized();
            var role = await _signInManager.UserManager.GetRolesAsync(user);
            return Ok(new
            {   //Edit here
                user.Id,
                user.FirstName,
                user.LastName,
                user.CustomerId,
                user.Email,
                Role = role
            });
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDto newAdmin)
        {
            var user = new User
            {
                UserName = newAdmin.Email,
                Email = newAdmin.Email,
                FirstName = newAdmin.FirstName,
                LastName = newAdmin.LastName
            };

            var result = await _signInManager.UserManager.CreateAsync(user, newAdmin.Password!);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.UserManager.AddToRoleAsync(user,"Admin");
            return Ok(new UserDto
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email!,
                Role = "Admin"
            });
        }


    }
}
