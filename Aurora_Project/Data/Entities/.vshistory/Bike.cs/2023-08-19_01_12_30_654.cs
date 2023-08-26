using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Bike
    {
        public int Id { get; set; }


        public string Brand { get; set; }


        public string Model { get; set; }


        public int Year { get; set; }


        public BikeTypes? BikeType { get; set; }


        public string Color { get; set; }
    }
}
