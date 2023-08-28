using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Customers
{
    public class CustomerCreateUpdateViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public String FirstName { get; set; }


        [Display(Name = "Last Name")]
        public String LastName { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        public Gender? Gender { get; set; }


        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        public string Address { get; set; }
    }
}
