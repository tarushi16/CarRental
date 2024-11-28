using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Repositories
{
    public interface ICarRepo
    {
        IActionResult AddCar(Car car);
        ActionResult<Car> UpdateCarAvailabilty(Guid id);
        ActionResult<IEnumerable<Car>> GetAvailableCars();
        ActionResult<Car> GetCarById(Guid id);

    }
}
