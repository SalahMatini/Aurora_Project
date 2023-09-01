using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }


        [Required]
        public String FirstName { get; set; }


        [Required]
        public String LastName { get; set; }


        public string FullName 
        {
            get 
            {
               return $"{FirstName} {LastName}";
            }
                
        }

        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                TimeSpan ageSpan = today - DateOfBirth;

                
                int age = (int)Math.Floor(ageSpan.TotalDays / 365.25);

                return age;
            }
        }


        [Required]
        public string Email { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }


        public int OrderId { get; set; }


        public List<Order> Orders { get; set; }



    }
}
