using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Bikes;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aurora_Project.AutoMapperProfiles
{
    public class BikeAutoMapperProfilecs : Profile
    {
        public BikeAutoMapperProfilecs()
        {
            CreateMap<Bike, BikeIndexViewModel>();

            CreateMap<Bike, BikeDetailsViewModel>();
        }
    }
}
