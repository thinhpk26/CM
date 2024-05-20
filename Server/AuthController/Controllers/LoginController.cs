using Application.IService;
using AuthAppication.DTO;
using AuthAppication.IServices;
using Repo.Entities;
using AuthRepo.Models;
using Controller.Controllers;
using Controller.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthAppication.DTO.ConfirmCode;

namespace AuthController.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : BaseController<UserPlatForm, UserPlatFormGetDTO, UserPlatFormInsertDTO, UserPlatFormUpdateDTO>
    {
        private readonly ILoginService Service;
        private readonly IConfirmCodeService ConfirmService;
        public LoginController(ILoginService service, IConfirmCodeService confirmService) : base(service)
        {
            Service = service;
            ConfirmService = confirmService;
        }

        [HttpPost("Request-login")]
        public async Task<ResponseResult<Dictionary<string, object>>> Login(LoginInforModel loginInfor)
        {
            var result = new ResponseResult<Dictionary<string, object>>();
            var data = new Dictionary<string, object>();
            var token = await Service.Login(loginInfor);
            data.Add("Token", token);
            result.Data = data;
            return result;
        }

        [HttpPost("ChangeCompany")]
        public async Task<ResponseResult<Dictionary<string, object>>> ChangeCompany(ChangeCompany changeCompanyModel)
        {
            var result = new ResponseResult<Dictionary<string, object>>();
            var data = new Dictionary<string, object>();
            var token = await Service.ChangeCompany(changeCompanyModel.CompanyID, changeCompanyModel.UserID);
            data.Add("Token", token);
            result.Data = data;
            return result;
        }

        [HttpGet("ConfirmCode/{companyID}")]
        public async Task<ResponseResult<ConfirmCodeGetDTO>> GenerateConfirmCode([FromRoute]long companyID)
        {
            var result = new ResponseResult<ConfirmCodeGetDTO>();
            result.Data = await ConfirmService.CreateConfirmCode(companyID);
            return result;
        }

        /// <summary>
        /// Check user đã đúng chưa
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        [HttpPost("User/ByAccountPassword")]
        public async Task<ResponseResult<UserPlatFormGetDTO>> GetUserPlatformByAccountPassword(LoginInforModel loginInfor)
        {
            var result = new ResponseResult<UserPlatFormGetDTO>();
            result.Data = await Service.GetUserPlatformByAccountPassword(loginInfor.Account, loginInfor.Password);
            return result;
        }

        [HttpPut("UserPlatform/{id}/CompanyCode/{companyCode}")]
        public async Task<ResponseResult<bool>> UpdateIsAllowUserAccess([FromRoute]long id, [FromRoute]string companyCode, [FromBody] bool isAllowAccess)
        {
            var result = new ResponseResult<bool>();
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = await Service.UpdateIsAllowUserAccess(id, companyCode, isAllowAccess);
            return result;
        }
    }
}
