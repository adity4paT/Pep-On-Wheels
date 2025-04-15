using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Address;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressReadDTO>();
        CreateMap<AddressCreateDTO, Address>();
        CreateMap<AddressUpdateDTO, Address>();
    }
}
