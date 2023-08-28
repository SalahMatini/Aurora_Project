using Aurora_Project.Data.Entities;
using Aurora_Project.Models.Customers;
using AutoMapper;


namespace Aurora_Project.AutoMapperProfiles
{
    public class CustomerAutoMapperProfile : Profile
    {
       public CustomerAutoMapperProfile()
       {
            CreateMap<Customer, CustomerIndexViewModel>();
       }
    }
}
