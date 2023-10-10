using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Orders;
using AutoMapper;

namespace Aurora_Project.AutoMapperProfiles
{
    public class OrderAutoMapperProfile : Profile
    {

        public OrderAutoMapperProfile()
        {

            CreateMap<Order, OrderListViewModel>();

            CreateMap<Order, OrderDetailsViewModel>();

            CreateMap<OrderCreateUpdateViewModel, Order>();

            CreateMap<Order, OrderCreateUpdateViewModel>()
                .ForMember(dest => dest.BikeIds,
                opts => opts.MapFrom(src => src.Bikes.Select(bike => bike.Id).ToList()));

        }

    }
}
