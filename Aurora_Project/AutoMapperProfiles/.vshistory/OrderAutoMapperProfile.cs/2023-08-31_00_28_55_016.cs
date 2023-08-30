using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Orders;
using AutoMapper;

namespace Aurora_Project.AutoMapperProfiles
{
    public class OrderAutoMapperProfile : Profile
    {

        public OrderAutoMapperProfile()
        {

            CreateMap<Order, OrderIndexViewModel>();

        }

    }
}
