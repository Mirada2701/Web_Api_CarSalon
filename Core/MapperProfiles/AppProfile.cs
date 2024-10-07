using AutoMapper;
using Core.Dtos;
using Core.Models;
using Data.Entities;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateCarModel, Car>();
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}
