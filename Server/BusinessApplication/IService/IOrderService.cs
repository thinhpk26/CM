using Application.IService;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface IOrderService : IBaseService<Order, OrderGetDTO, OrderInsertDTO, OrderUpdateDTO>
    {
    }
}
