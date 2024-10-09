using Core.Dtos;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_CarSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            await accountService.Register(model);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {            
            return Ok(await accountService.Login(model));
        }
        [HttpPost("logout")]
        public IActionResult Logout(LoginDto model)
        {

            return Ok();
        }
    }
}
