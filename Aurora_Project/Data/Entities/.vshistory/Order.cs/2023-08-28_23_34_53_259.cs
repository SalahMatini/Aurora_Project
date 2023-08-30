using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class BikeType
    {
        public int Id { get; set; }


        [Required]
        public string Type { get; set; }


        public List<Bike> Bikes { get; set; }
    }
}
