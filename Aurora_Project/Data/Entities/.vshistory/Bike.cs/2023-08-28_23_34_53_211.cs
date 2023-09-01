using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Bike
    {
        public int Id { get; set; }


        [Required]
        public string Brand { get; set; }


        [Required]
        public string Model { get; set; }


        [Required]
        public int Year { get; set; }


        [Required]
        public string Color { get; set; }


        [Required]
        public decimal Price { get; set; }


        public int? BikeTypeId { get; set; }


        public BikeType BikeType { get; set; }
    }
}
