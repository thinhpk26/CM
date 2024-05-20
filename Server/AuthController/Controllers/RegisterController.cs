using AuthAppication.IServices;
using AuthRepo.Models;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;

namespace AuthController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisService _regisService;
        public RegisterController(IRegisService regisService)
        {
            _regisService = regisService;
        }

        /// <summary>
        /// Đăng ký domain mới
        /// </summary>
        /// <returns></returns>
        [HttpPost("Company")]
        public async Task<ResponseResult<bool>> RegisNewDomain([FromBody]RegisNewDomainModel regisInfor)
        {
            var result = new ResponseResult<bool>();
            var isSuccess = await _regisService.RegisNewDomain(regisInfor);
            result.StatusCode = StatusCodes.Status201Created;
            result.Data = isSuccess;
            return result;
        }

        /// <summary>
        /// Đăng ký làm nhân viên
        /// </summary>
        /// <returns></returns>
        [HttpPost("User/{inviteCode}")]
        public async Task<ResponseResult<bool>> RegisEmployee([FromRoute]Guid inviteCode, RegisEmployeeModel regisInfor)
        {
            var result = new ResponseResult<bool>();
            var isSuccess = await _regisService.RegisEmployee(inviteCode, regisInfor);
            result.StatusCode = StatusCodes.Status201Created;
            result.Data = isSuccess;
            return result;
        }
    }
}
