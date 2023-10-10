using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Customers
{
    public class CustomerListViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Full Name")]
        public String FullName { get; set; }


        public Gender Gender { get; set; }


        public int Age { get; set; }


        public string Email { get; set; }
    }
}
