using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class RentCarDetails
    {
   //not in DB
        [Required]
        public Guid id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
