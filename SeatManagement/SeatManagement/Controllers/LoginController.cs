using BuisnessLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogin _loginService;
        public LoginController(ILogin loginService)
        {
            this._loginService = loginService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid credentials");

            string JwtToken = _loginService.login(user);

            if ( JwtToken != null)
                return Ok(JsonConvert.SerializeObject(JwtToken));
            else
                return Unauthorized();
        }
    }
}
