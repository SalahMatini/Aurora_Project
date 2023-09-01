using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Bikes;
using Aurora_Project.Models.Orders;
using AutoMapper;

namespace Aurora_Project.AutoMapperProfiles
{
    public class BikeAutoMapperProfilecs : Profile
    {
        public BikeAutoMapperProfilecs()
        {
            CreateMap<Bike, BikeIndexViewModel>();

            CreateMap<Bike, BikeDetailsViewModel>();

            CreateMap<BikeCreateUpdateViewModel, Bike>();


            CreateMap<Order, OrderCreateUpdateViewModel>()
                .ForMember(dest => dest.BikeIds,
                opts => opts.MapFrom(src => src.Bikes.Select(bike => bike.Id).ToList()));
        }
    }
}
