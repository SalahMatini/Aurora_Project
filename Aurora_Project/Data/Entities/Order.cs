using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }


        public DateTime OrderDate { get; set; }


        public OrderStatus OrderStatus { get; set; }


        public string ShippingAddress { get; set; }


        public int? CustomerId { get; set; }


        public Customer Customer { get; set; }
    }
}
