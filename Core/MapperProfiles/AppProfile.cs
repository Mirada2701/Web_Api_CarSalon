using AutoMapper;
using Core.Dtos;
using Data.Entities;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateCarDto, Car>();
            CreateMap<CarDto, Car>().ReverseMap();
            CreateMap<EditCarDto, Car>();

            CreateMap<RegisterDto, User>()
               .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email))
               .ForMember(x => x.PasswordHash, opt => opt.Ignore());
        }
    }
}
