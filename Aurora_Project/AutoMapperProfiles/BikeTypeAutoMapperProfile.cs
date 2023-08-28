using Aurora_Project.Data.Entities;
using Aurora_Project.Models.BikeTypes;
using AutoMapper;

namespace Aurora_Project.AutoMapperProfiles
{
    public class BikeTypeAutoMapperProfile : Profile
    {
        public BikeTypeAutoMapperProfile()
        {
            CreateMap<BikeType, BikeTypeIndexViewModel>();

            CreateMap<BikeType, BikeTypeDetailsViewModel>();

            CreateMap<BikeTypeCreateUpdateViewModel, BikeType>().ReverseMap();
        }
    }
}
