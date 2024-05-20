using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Controller.Controllers;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;
using System.Net;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class LeadController : BaseController<Lead, LeadGetDTO, LeadInsertDTO, LeadUpdateDTO>
    {
        protected readonly ILeadService Service;
        public LeadController(ILeadService service) : base(service)
        {
            Service = service;
        }

        [HttpPost("ConvertAccount/{id}")]
        public async Task<ResponseResult<AccountGetDTO>> ConvertAccount([FromRoute] long id)
        {
            var result = new ResponseResult<AccountGetDTO>();
            result.Data = await Service.ConvertAccount(id);
            result.StatusCode = StatusCodes.Status201Created;
            return result;
        }
    }
}
