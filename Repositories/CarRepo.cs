using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class CarRepo : ControllerBase,ICarRepo
    {
        private readonly AppDbContext context;
        public CarRepo(AppDbContext context)
        {
            this.context = context;
        }

        //adding car data to DB
        public IActionResult AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
            return Ok();
        }

        //Toggle by Id
        public ActionResult<Car> UpdateCarAvailabilty(Guid id)
        {
            var car = context.Cars.Find(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} was not found.");
            }
            car.IsAvailable = !car.IsAvailable;
            context.SaveChanges();

            return Ok(car);
        }

       
        public ActionResult<Car> GetCarById(Guid id)
        {
            var result = context.Cars.Find(id);
            if (result == null) return NotFound($"Car with ID {id} was not found.");
            return Ok(result);
        }

        //Availability as true
        public ActionResult<IEnumerable<Car>> GetAvailableCars()
        {
            var result = context.Cars.Where(x=>x.IsAvailable==true);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
