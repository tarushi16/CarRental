using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Services
{
    public interface IUserService
    {
        IActionResult RegisterUser(User user);
        ActionResult LoginUser(LoginCredentials credentials);
    }
}
