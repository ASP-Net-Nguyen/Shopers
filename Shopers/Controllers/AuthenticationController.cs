using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopers.Models.Authentication;
using Shopers.Service.LoginService;

namespace Shopers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ProfileUser> _userManager;
        private readonly ILoginService _authService;
        public AuthenticationController(UserManager<ProfileUser> userManager, ILoginService authService)
        {
            this._authService = authService;
            this._userManager = userManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var status = await _authService.LoginAsync(model);

            if (status.StatusCode == 1)
                return Ok(status);
            return BadRequest(status);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            var response = await _authService.RegisterAsync(register);
            if (response.StatusCode == 0)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok();
        }
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword model, string username)
        {
            var status = await _authService.ChangePasswordAsync(model, username);
            if (status.StatusCode == 1)
                return Ok(status);
            return BadRequest(status);
        }
    }
}
