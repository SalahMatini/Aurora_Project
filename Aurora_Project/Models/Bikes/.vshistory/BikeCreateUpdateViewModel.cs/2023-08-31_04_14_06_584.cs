using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Bikes
{
    public class BikeCreateUpdateViewModel
    {
        public int Id { get; set; }


        public string Brand { get; set; }


        public string Model { get; set; }


        public int Year { get; set; }


        public string Color { get; set; }


        public decimal Price { get; set; }


        public int BikeTypeId { get; set; }



        [Display(Name = "Bikes")]
        public List<int> BikeIds { get; set; }


        [ValidateNever]
        public SelectList BikeTypesSelectList { get; set; }
    }
}
