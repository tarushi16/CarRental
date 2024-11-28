using CarRental.Data;
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("Login")]
        public ActionResult Login(LoginCredentials LoginCred)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return userService.LoginUser(LoginCred); 
        }

        [HttpPost("RegisterUser")]
        public IActionResult Signup(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return userService.RegisterUser(user);
        }
    }
}
