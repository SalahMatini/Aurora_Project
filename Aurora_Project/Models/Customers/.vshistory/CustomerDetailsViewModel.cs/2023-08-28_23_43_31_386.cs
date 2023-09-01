using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Customers
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Full Name")]
        public String FullName { get; set; }


        public Gender? Gender { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        public int Age { get; set; }


        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        public string Address { get; set; }
    }
}
