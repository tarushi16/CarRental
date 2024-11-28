using CarRental.Models;
using CarRental.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Services
{
    public class UserService:ControllerBase,IUserService
    {
        private readonly IUserRepo userrepo;
        public UserService(IUserRepo userrepo)
        {
            this.userrepo = userrepo;
        }

        
        public IActionResult RegisterUser(User user)
        {
            return userrepo.RegisterUser(user);
        }
        public ActionResult LoginUser(LoginCredentials credentials)
        {
            return userrepo.LoginUser(credentials);
        }
    }
}
