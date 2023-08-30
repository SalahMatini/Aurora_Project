using Aurora_Project.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Models.Orders
{
    public class OrderCreateUpdateViewModel
    {


        public int Id { get; set; }


        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }


        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }


        public int CustomerId { get; set; }


        [ValidateNever]
        public SelectList CustomersSelectList { get; set; }
    }
}
