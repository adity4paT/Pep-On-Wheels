using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Cart;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Cart, CartReadDTO>();
        CreateMap<CartItem, CartItemReadDTO>();
    }
}
