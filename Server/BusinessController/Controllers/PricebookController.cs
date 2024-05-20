using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class PricebookController : BaseController<Pricebook, PricebookGetDTO, PricebookInsertDTO, PricebookUpdateDTO>
    {
        public PricebookController(IPricebookService service) : base(service)
        {
        }
    }
}
