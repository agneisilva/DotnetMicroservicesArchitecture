using System;
using Microsoft.AspNetCore.Mvc;

namespace actio.services.identity.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Identity API!");
    }
}
