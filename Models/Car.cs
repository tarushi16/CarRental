using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Car
    {
        public Guid Id { get; set; } 

        [Required]
        [StringLength(50, ErrorMessage = "Make cannot be longer than 50 characters.")]
        public string Make { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters.")]
        public string Model { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price per day must be greater than 0.")]
        public int PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
