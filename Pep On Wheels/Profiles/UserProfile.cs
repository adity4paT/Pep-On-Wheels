using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDTO>();
        CreateMap<UserCreateDTO, User>();
    }
}
