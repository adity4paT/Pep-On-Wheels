using AutoMapper;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.DTO.Order;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderReadDTO>();
        CreateMap<OrderItem, OrderItemReadDTO>();
        CreateMap<OrderCreateDTO, Order>();
    }
}
