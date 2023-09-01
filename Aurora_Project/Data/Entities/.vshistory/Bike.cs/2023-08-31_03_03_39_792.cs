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


        public string Title
        {
            get
            {
                return $"{Brand}: {Model} - {Year}";
            }
        }


        [Required]
        public int Year { get; set; }


        [Required]
        public string Color { get; set; }


        [Required]
        public decimal Price { get; set; }


        public int? BikeTypeId { get; set; }


        public BikeType BikeType { get; set; }


        public List<Order> Orders { get; set; }
    }
}
