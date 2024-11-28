using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Repositories
{
    public interface IUserRepo
    {
        IActionResult RegisterUser(User user);
        ActionResult LoginUser(LoginCredentials credentials);
    }
}
