using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessApplication.Service;
using Controller.Controllers;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LayoutColumnController : BaseController<LayoutColumn, LayoutColumnGetDTO, LayoutColumnInsertDTO, LayoutColumnUpdateDTO>
    {
        public readonly ILayoutColumnService Service;
        public LayoutColumnController(ILayoutColumnService service) : base(service)
        {
            Service = service;
        }

        /// <summary>
        /// Lấy cột hiển thị theo layout code
        /// </summary>
        /// <returns></returns>
        [HttpGet("LayoutCode/{layoutCode}")]
        public async Task<ResponseResult<List<LayoutColumnGetDTO>>> GetColumnsByLayoutCode(string layoutCode)
        {
            var layoutColumnList = await Service.GetColumnsByLayoutCode(layoutCode);
            var result = new ResponseResult<List<LayoutColumnGetDTO>>()
            {
                StatusCode = StatusCodes.Status200OK,
                Data = layoutColumnList
            };
            return result;
        }
    }
}
