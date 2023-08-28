using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(50)]
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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2007-08-28", ErrorMessage = "Customer Must Be 16 Years Or Older")]
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
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required]
        [MaxLength (20)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
