using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController<User, UserGetDTO, UserInsertDTO, UserUpdateDTO>
    {
        private readonly IUserService Service;
        public UserController(IUserService service) : base(service)
        {
            Service = service;
        }
    }
}
