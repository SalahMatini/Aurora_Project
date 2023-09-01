using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Bikes
{
    public class BikeDetailsViewModel
    {

        public int Id { get; set; }


        public string Brand { get; set; }


        public string Model { get; set; }


        public int Year { get; set; }


        public string Color { get; set; }


        public decimal Price { get; set; }


        [Display(Name = "Bike Type")]
        public string BikeTypeType { get; set; }
    }
}
