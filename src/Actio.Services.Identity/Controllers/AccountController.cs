using System;
using System.Threading.Tasks;
using actio.services.identity.Services;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;

namespace actio.services.identity.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task Login([FromBody] AuthenticateUser command)
            => await _userService.LoginAsync(command.Email, command.Password);
    }
}
