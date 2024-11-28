using CarRental.Models;
using CarRental.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRental.Services
{
    public class CarService : ControllerBase,ICarService
    {
        private readonly ICarRepo carRepo;
        private readonly IEmailService emailService;
        public CarService(ICarRepo carRepo,IEmailService emailService)
        {
            this.carRepo = carRepo;
            this.emailService = emailService;
        }


        //car addition
        public IActionResult addCar(Car car)
        {
           return carRepo.AddCar(car);
        }

        //update car
        public ActionResult<Car> UpdateCarAvailability(Guid id)
        {
            return carRepo.UpdateCarAvailabilty(id);
        }

        //get cars
        public ActionResult<IEnumerable<Car>> GetAvailableCars()
        {
            return carRepo.GetAvailableCars();
        }

        public ActionResult<Car> GetCarById(Guid id)
        {
            return carRepo.GetCarById(id);
        }


        //car availability check
        public ActionResult<Car> RentCar(RentCarDetails details)
        {
            //Using Id
            var actionResult = carRepo.GetCarById(details.id);

            //check if car found
            if (actionResult.Result is NotFoundObjectResult) return NotFound();
            var currCar = (actionResult.Result as OkObjectResult)?.Value as Car;
            if (currCar == null) return NotFound();

            //car available?
            if (!currCar.IsAvailable) return NotFound("Car is currently unavailable");
        
            carRepo.UpdateCarAvailabilty(details.id);

            string carDetails = $"Your car's id is {currCar.Id} Car model is {currCar.Model} Price per day will be {currCar.PricePerDay}";
            
            //mail service
            emailService.SendEmailAsync(details.Email,"Car Details", carDetails);
            return Ok(currCar);
        }
    }
}
