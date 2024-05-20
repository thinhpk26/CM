using Repo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Controller.Controllers;
using BusinessApplication.DTO;
using Application.IService;
using BusinessApplication.IService;
using Controller.Response;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController<Account, AccountGetDTO, AccountInsertDTO, AccountUpdateDTO>
    {
        private readonly IAccountService Service;
        public AccountController(IAccountService service) : base(service)
        {
            Service = service;
        }

        [HttpGet("ConvertOrder/{id}")]
        public async Task<ResponseResult<OrderGetDTO>> ConvertOrder([FromRoute]long id)
        {
            var result = new ResponseResult<OrderGetDTO>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.ConvertOrder(id);
            return result;
        }

    }
}
