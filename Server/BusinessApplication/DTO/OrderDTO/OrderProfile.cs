using AutoMapper;
using Repo.Entities;

namespace BusinessApplication.DTO.OrderDTO
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderGetDTO>();
            CreateMap<OrderInsertDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();
        }
    }
}
