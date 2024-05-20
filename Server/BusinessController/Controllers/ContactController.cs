using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : BaseController<Contact, ContactGetDTO, ContactInsertDTO, ContactUpdateDTO>
    {
        public ContactController(IContactService service) : base(service)
        {
        }
    }
}
