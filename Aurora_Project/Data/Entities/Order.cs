using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Order
    {

        public Order()
        {
            Bikes = new List<Bike>();
        }


        public int Id { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }


        [Required]
        public OrderStatus OrderStatus { get; set; }


        [Required]
        public string ShippingAddress { get; set; }


        public int? CustomerId { get; set; }


        public Customer Customer { get; set; }


        public List<Bike> Bikes { get; set; }


        public decimal TotalPrice
        {
            get
            {
                if (Bikes == null)
                    return 0;

                decimal total = 0;

                foreach (var bike in Bikes)
                {
                    total += bike.Price;
                }

                return total;
            }
        }
    }
}
