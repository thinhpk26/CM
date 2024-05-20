using Repo.Entities;
using Repo.IRepo;
using System.Data.Common;

namespace AuthRepo.IRepos
{
    public interface IUserRepo : IBaseRepo<User>
    {
        /// <summary>
        /// Lấy người dùng theo người dùng platform
        /// </summary>
        /// <param name="userFlatformID"></param>
        /// <returns></returns>
        public Task<User> GetUserByUserPlatformID(long userFlatformID, Company company);

        /// <summary>
        /// Thêm người dùng bằng command
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> CreateUserByCommand(string DbSave, User user);

        /// <summary>
        /// Lấy người dùng theo account
        /// </summary>
        /// <returns></returns>
        public Task<User> GetUserByAccount(string account, DbConnection otherCnn = null, DbTransaction otherTran = null);
    }
}
