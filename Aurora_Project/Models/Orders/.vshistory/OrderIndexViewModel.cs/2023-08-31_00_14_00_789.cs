using Aurora_Project.Data.Entities;
using Aurora_Project.Enums;

namespace Aurora_Project.Models.Orders
{
    public class OrderIndexViewModel
    {
        public int Id { get; set; }


        public DateTime OrderDate { get; set; }


        public OrderStatus OrderStatus { get; set; }


        public string ShippingAddress { get; set; }


        public int? CustomerId { get; set; }


        public Customer Customer { get; set; }

    }
}
