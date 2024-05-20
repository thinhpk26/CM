using Application.IService;
using AuthAppication.DTO.CompanyDTO;
using AuthAppication.DTO;
using AuthAppication.IServices;
using AuthAppication.Services;
using AuthRepo.Models;
using Controller.Controllers;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace AuthController.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : BaseController<Company, CompanyGetDTO, CompanyInsertDTO, CompanyUpdateDTO>
    {
        private readonly ICompanyService Service;
        public CompanyController(ICompanyService service) : base(service)
        {
            Service = service;
        }

        /// <summary>
        /// Lấy công ty theo tài khoản, mật khẩu người dùng
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost("ByAccountPassword")]
        public async Task<ResponseResult<List<CompanyGetDTO>>> GetCompanyByAccountPassword(CompanyByAccountPassword infor)
        {
            var result = new ResponseResult<List<CompanyGetDTO>>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.GetCompanyByAccountPassword(infor);
            return result;
        }

        /// <summary>
        /// Lấy company của người dùng theo companyCode
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpGet("UserID/{userID}")]
        public async Task<ResponseResult<List<CompanyGetDTO>>> GetAllCompanyOfUserByUserID([FromRoute]string userID)
        {
            var result = new ResponseResult<List<CompanyGetDTO>>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.GetAllCompanyOfUserByUserID(userID);
            return result;
        }

        /// <summary>
        /// Lấy công ty theo confirm code
        /// </summary>
        /// <param name="confirmCode"></param>
        /// <returns></returns>
        [HttpGet("ConfirmCode/{confirmCode}")]
        public async Task<ResponseResult<CompanyGetDTO>> GetCompanyByConfirmCode(string confirmCode)
        {
            var result = new ResponseResult<CompanyGetDTO>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.GetCompanyByConfirmCode(confirmCode);
            return result;
        }

        /// <summary>
        /// Lấy người dùng theo công ty
        /// </summary>
        /// <param name="confirmCode"></param>
        /// <returns></returns>
        [HttpGet("User/{CompanyCode}")]
        public async Task<ResponseResult<List<UserPlatForm>>> GetUserPlatformByCompanyCode(string companyCode)
        {
            var result = new ResponseResult<List<UserPlatForm>>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.GetUserPlatformByCompanyCode(companyCode);
            return result;
        }
    }
}
