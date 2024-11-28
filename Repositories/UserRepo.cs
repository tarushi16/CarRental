using CarRental.Data;
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class UserRepo : ControllerBase,IUserRepo
    {
        private readonly AppDbContext context;
        private readonly JwtService jwtsvc;
        public UserRepo(AppDbContext context , JwtService jwtsvc)
        {
            this.context = context;
            this.jwtsvc = jwtsvc;
        }


        //user log in 
        public IActionResult RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return Ok();
        }


        //token generation
        public ActionResult LoginUser(LoginCredentials
            loginCredentials)
        {
            User user =  context.Users.FirstOrDefault(u => u.Email == loginCredentials.Email && u.Password == loginCredentials.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.Role == "Admin")
            {
                var token = jwtsvc.GenerateToken(user.Name, "Admin");
                return  Ok(token);
            }
            if (user.Role == "User")
            {
                var token = jwtsvc.GenerateToken(user.Name, "User");
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
