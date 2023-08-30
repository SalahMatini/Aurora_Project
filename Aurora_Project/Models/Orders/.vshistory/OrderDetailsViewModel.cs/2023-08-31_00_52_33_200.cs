using Aurora_Project.Data.Entities;
using Aurora_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Orders
{
    public class OrderDetailsViewModel
    {


        public int Id { get; set; }


        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }


        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }


        public int? CustomerId { get; set; }


        public Customer Customer { get; set; }
    }
}
