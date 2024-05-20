using Repo.Entities;
using AuthRepo.Models;
using Repo.IRepo;

namespace AuthRepo.IRepos
{
    public interface IUserPlatFormRepo : IBaseRepo<UserPlatForm>
    {
        /// <summary>
        /// Lấy nhân viên theo thông tin login
        /// </summary>
        /// <param name="loginInforModel"></param>
        /// <returns></returns>
        Task<UserPlatForm?> GetUserByAccountPassword(string account, string password);

        /// <summary>
        /// Lấy người dùng theo account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Task<UserPlatForm> GetUserByAccount(string account);

        public Task<bool> UpdateIsAllowUserAccess(long id, string companyCode, bool isAllowAccess);
    }
}
