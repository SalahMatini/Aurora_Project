using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Bikes;
using AutoMapper;

namespace Aurora_Project.AutoMapperProfiles
{
    public class BikeAutoMapperProfile : Profile
    {
        public BikeAutoMapperProfile() {

            CreateMap<Bike, BikeViewModel>();
        
        }
    }
}
