using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.DTO.OrderDTO;
using BusinessApplication.IService;
using Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseController<Order, OrderGetDTO, OrderInsertDTO, OrderUpdateDTO>
    {
        public OrderController(IOrderService service) : base(service)
        {
        }
    }
}
