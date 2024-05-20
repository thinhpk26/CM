using Application.IService;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessApplication.Service;
using BusinessRepo.Models;
using Controller.Controllers;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;
using Repo.Models;

namespace BusinessController.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController<Product, ProductGetDTO, ProductInsertDTO, ProductUpdateDTO>
    {
        protected readonly IProductService Service;
        public ProductController(IProductService service) : base(service)
        {
            Service = service;
        }

        [HttpPost("Pricebook/Account")]
        public async Task<ResponseResult<List<ProductApplyPricebook>>> ProductApplyPricebook(string? ids)
        {
            var result = new ResponseResult<List<ProductApplyPricebook>>();
            result.Data = await Service.ProductApplyPricebook(ids);
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }
    }
}
