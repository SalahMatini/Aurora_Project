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
            CreateMap<Bike, BikeListViewModel>();

            CreateMap<Bike, BikeDetailsViewModel>();

            CreateMap<BikeCreateUpdateViewModel, Bike>().ReverseMap();

        }
    }
}
