using Repo.Entities;
using AuthRepo.IRepos;
using AuthRepo.Models;
using Dapper;
using Repo.Repo;
using Repo.UnitOfWork;
using System.Data.Common;
using System.Security.Principal;
using Repo.Models;

namespace AuthRepo.Repos
{
    public class UserPlatFormRepo : BaseRepo<UserPlatForm>, IUserPlatFormRepo
    {
        public UserPlatFormRepo(IConfiguration config, IUnitOfWork unitOfWork) : base(config, unitOfWork)
        {
        }

        public async Task<UserPlatForm?> GetUserByAccountPassword(string account, string password)
        {
            var query = $"SELECT * FROM {GetTableName()} WHERE Email = @Account AND Password = @Password";

            var param = new DynamicParameters();
            param.Add("Account", account);
            param.Add("Password", password);

            var result = await Cnn.QueryFirstOrDefaultAsync<UserPlatForm>(query, param, UnitOfWork.GetTransaction());

            return result;
        }

        public async Task<UserPlatForm> GetUserByAccount(string account)
        {
            var query = $"SELECT * FROM {GetTableName()} WHERE Email = @Account";

            var param = new DynamicParameters();
            param.Add("Account", account);

            var result = await Cnn.QueryFirstOrDefaultAsync<UserPlatForm>(query, param, UnitOfWork.GetTransaction());

            return result;
        }

        public async Task<bool> UpdateIsAllowUserAccess(long id, string companyCode, bool isAllowAccess)
        {
            var query = $"UPDATE company_user_mapping cum JOIN user_platform up ON up.ID = cum.UserID JOIN company c ON c.ID = cum.CompanyID SET cum.IsAllowAccess = @IsAllowAccess WHERE up.ID = @ID AND c.CompanyCode = @CompanyCode";

            var param = new DynamicParameters();
            param.Add("ID", id);
            param.Add("IsAllowAccess", isAllowAccess);
            param.Add("CompanyCode", companyCode);

            var result = await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());

            return result > 0;
        }
    }
}
