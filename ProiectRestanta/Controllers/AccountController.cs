using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProiectRestanta.Entities;
using ProiectRestanta.Models.Constants;
using ProiectRestanta.Models.Entities.DTOs;
using ProiectRestanta.Services.UserServices;

namespace ProiectRestanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<User> userManager,
            IUserService userService
            )
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register-admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User Already registered!");
            }

            var result = await _userService.RegisterAdminAsync(dto);
            
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("register-user")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User Already registered!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto) 
        {
            var token = await _userService.LoginUser(dto);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
