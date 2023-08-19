using Aurora_Project.Enums;

namespace Aurora_Project.Models.Bikes
{
    public class BikeViewModel
    {
        public int Id { get; set; }


        public string Brand { get; set; }


        public string Model { get; set; }


        public int Year { get; set; }


        public BikeTypes? BikeType { get; set; }


        public string Color { get; set; }
    }
}
