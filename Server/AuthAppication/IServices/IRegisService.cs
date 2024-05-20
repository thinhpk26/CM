using AuthRepo.Models;
using Repo.Entities;

namespace AuthAppication.IServices
{
    public interface IRegisService
    {
        /// <summary>
        /// Đăng ký domain mới
        /// </summary>
        public Task<bool> RegisNewDomain(RegisNewDomainModel regisInfor);

        /// <summary>
        /// Đăng ký nhân viên
        /// </summary>
        public Task<bool> RegisEmployee(Guid inviteCode, RegisEmployeeModel regisInfor);

        /// <summary>
        /// Kiểm tra Token
        /// </summary>
        /// <returns></returns>
        public Task<ConfirmCode> ValidateConfirmToken(Guid confirmCode);

        /// <summary>
        /// Lấy company theo confirm token
        /// </summary>
        /// <returns></returns>
        public Task<Company> GetCompanyByConfirmToken(Guid confirmCode);
    }
}
