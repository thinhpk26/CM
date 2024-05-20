using Application.IService;
using AuthAppication.DTO;
using AuthAppication.DTO.CompanyDTO;
using Repo.Entities;
using AuthRepo.Models;
using Repo.Context;

namespace AuthAppication.IServices
{
    public interface ILoginService : IBaseService<UserPlatForm, UserPlatFormGetDTO, UserPlatFormInsertDTO, UserPlatFormUpdateDTO>
    {
        /// <summary>
        /// Login vào máy chủ
        /// </summary>
        /// <param name="loginInfor"></param>
        /// <returns></returns>
        Task<string> Login(LoginInforModel loginInfor);
        /// <summary>
        /// Tạo ra 1 token mới
        /// </summary>
        /// <param name="user"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        string GenerateJsonToken(UserContext user, CompanyContext company);

        /// <summary>
        /// Lấy người dùng theo Tài khoản mật khẩu
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public Task<UserPlatFormGetDTO> GetUserPlatformByAccountPassword(string account, string password);

        /// <summary>
        /// Thay đổi công ty
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Task<string> ChangeCompany(int comapnyID, int userID);

        /// <summary>
        /// Cập nhật cho người dùng truy cập platform
        /// </summary>
        /// <param name="isAllowAccess"></param>
        /// <returns></returns>
        public Task<bool> UpdateIsAllowUserAccess(long id, string companyCode, bool isAllowAccess);
    }
}
