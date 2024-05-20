using Repo.Entities;
using AuthRepo.Models;
using Repo.IRepo;

namespace AuthRepo.IRepos
{
    public interface ICompanyRepo : IBaseRepo<Company>
    {
        /// <summary>
        /// Lấy thông tin công ty bằng thông tin login
        /// </summary>
        /// <param name="loginInforModel"></param>
        /// <returns></returns>
        Task<Company> GetCompanyByLoginInfor(LoginInforModel loginInforModel);

        /// <summary>
        /// Tạo công ty mới
        /// </summary>
        /// <param name="dbSave"></param>
        /// <returns></returns>
        Task<bool> CreateNewCompany(string dbSave);

        /// <summary>
        /// thêm mapping giữa user và company
        /// </summary>
        /// <param name="user"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public Task<int> InsertCompanyUserMapping(UserPlatForm user, Company company);

        /// <summary>
        /// Lấy công ty theo mã công ty
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public Task<Company> GetCompanyByCompanyCode(string companyCode);

        /// <summary>
        /// Lấy company theo tài khoản mật khẩu
        /// </summary>
        /// <param name="loginInfor"></param>
        /// <returns></returns>
        public Task<List<Company>> GetCompanyByAccountPassword(CompanyByAccountPassword infor);

        /// <summary>
        /// Lấy tàon bộ công ty theo người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Task<List<Company>> GetAllCompanyByUserID(string userID);

        /// <summary>
        /// Lấy company theo confirmcode
        /// </summary>
        /// <param name="confirmCode"></param>
        /// <returns></returns>
        public Task<Company> GetCompanyByConfirmCode(string confirmCode);

        /// <summary>
        /// Lấy người dùng theo companyCode
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        public Task<List<UserPlatForm>> GetUserPlatformByCompanyCode(string CompanyCode);
    }
}
