using CarRental.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarRental.Models;

namespace Car_Rental_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("GetAvailableCars")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<IEnumerable<Car>> GetAvailableCars()
        {
            return carService.GetAvailableCars();
        }

        [HttpPost("addCar")]
        [Authorize(Roles = "Admin")]
        public IActionResult addCar(Car car)
        {
            Console.WriteLine("hereiam");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return carService.addCar(car);
        }

        [HttpPut("UpdateCarAvailabilty")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Car> UpdateCarAvailabilty(Guid id)
        {
            return carService.UpdateCarAvailability(id);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<Car> GetCarById(Guid id)
        {
            return carService.GetCarById(id);
        }

        [HttpPut("RentCar")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<Car> RentCar(RentCarDetails details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine("here controller");
            return carService.RentCar(details);
        }
    }
}
