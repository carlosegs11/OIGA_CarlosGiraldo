using AutoMapper;
using Service.api.security.register.DTOs;
using Service.api.security.register.Entities;

namespace Service.api.security.register.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreationDTO, User>();
        }
    }
}
