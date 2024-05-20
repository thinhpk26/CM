using Repo.Entities;
using AuthRepo.IRepos;
using AuthRepo.Models;
using Dapper;
using Microsoft.AspNetCore.Hosting.Server;
using MySqlConnector;
using Repo.IRepo;
using Repo.Repo;
using Repo.UnitOfWork;
using System.Data.Common;

namespace AuthRepo.Repos
{
    public class CompanyRepo : Repo.Repo.BaseRepo<Company>, ICompanyRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompanyRepo(IConfiguration config, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(config, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateNewCompany(string dbSave)
        {
            var queryCreateDB = $"DROP DATABASE IF EXISTS {dbSave}; CREATE DATABASE {dbSave}; USE {dbSave};";
            var InsertDataScript = File.ReadAllText("D:\\School\\Course_8\\Đồ án tốt nghiệp\\Server\\RepoNew\\script\\CreateDB.sql");
            var script = $"{queryCreateDB} {InsertDataScript}";
            var cmd = UnitOfWork.GetConnection().CreateCommand();
            cmd.CommandText = script;
            cmd.Transaction = UnitOfWork.GetTransaction();
            await cmd.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<Company> GetCompanyByLoginInfor(LoginInforModel loginInforModel)
        {
            var query = "SELECT c.* FROM company_user_mapping cum JOIN user_platform u on cum.UserID = u.ID JOIN company c ON c.ID = cum.CompanyID WHERE u.Email = @Account AND u.Password = @Password AND cum.CompanyCode = @CompanyCode";

            var param = new DynamicParameters();
            param.Add("Account", loginInforModel.Account);
            param.Add("Password", loginInforModel.Password);
            param.Add("CompanyCode", loginInforModel.CompanyCode);

            var result = await Cnn.QueryFirstOrDefaultAsync<Company>(query, param);

            return result;
        }

        public async Task<int> InsertCompanyUserMapping(UserPlatForm user, Company company)
        {
            var query = $"INSERT INTO company_user_mapping(CompanyID, UserID, CompanyCode, CompanyName, UserName) VALUES (@CompanyID, @UserID, @CompanyCode, @CompanyName, @UserName);";
            var companyUserMapping = new CompanyUserMapping()
            {
                CompanyID = company.ID,
                UserID = user.ID,
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                UserName = user.FullName
            };
            var result = await Cnn.ExecuteAsync(query, companyUserMapping, UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<Company> GetCompanyByCompanyCode(string companyCode)
        {
            var query = $"SELECT * FROM {GetTableName()} WHERE CompanyCode = @CompanyCode";
            var param = new DynamicParameters();
            param.Add("CompanyCode", companyCode);
            var result = await Cnn.QueryFirstOrDefaultAsync<Company>(query, param, UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<List<Company>> GetCompanyByAccountPassword(CompanyByAccountPassword infor)
        {
            var query = "SELECT c.*, cum.IsAllowAccess as IsAllowAccess FROM company_user_mapping cum JOIN user_platform u on cum.UserID = u.ID JOIN company c ON c.ID = cum.CompanyID WHERE u.Email = @Account AND u.Password = @Password";

            var param = new DynamicParameters();
            param.Add("Account", infor.Account);
            param.Add("Password", infor.Password);

            var result = await Cnn.QueryAsync<Company>(query, param, UnitOfWork.GetTransaction());

            return result.ToList();
        }

        public async Task<List<Company>> GetAllCompanyByUserID(string userID)
        {
            var query = "SELECT c.* FROM company_user_mapping cum JOIN user_platform u on cum.UserID = u.ID JOIN company c ON c.ID = cum.CompanyID WHERE u.ID = @UserID";

            var param = new DynamicParameters();
            param.Add("UserID", userID);

            var result = await Cnn.QueryAsync<Company>(query, param, UnitOfWork.GetTransaction());

            return result.ToList();
        }

        public async Task<Company> GetCompanyByConfirmCode(string confirmCode)
        {
            var query = "SELECT c.* FROM confirm_code cc JOIN company c ON cc.CompanyID = c.ID WHERE ConfirmCode = @ConfirmCode";

            var param = new DynamicParameters();
            param.Add("ConfirmCode", confirmCode);

            var result = await Cnn.QueryFirstOrDefaultAsync<Company>(query, param, UnitOfWork.GetTransaction());

            return result;
        }

        public async Task<List<UserPlatForm>> GetUserPlatformByCompanyCode(string companyCode)
        {
            var query = "SELECT up.*, cum.IsAllowAccess FROM user_platform up JOIN company_user_mapping cum ON up.ID = cum.UserID JOIN company c ON c.ID = cum.CompanyID WHERE c.CompanyCode = @CompanyCode";

            var param = new DynamicParameters();
            param.Add("CompanyCode", companyCode);

            var result = await Cnn.QueryAsync<UserPlatForm>(query, param, UnitOfWork.GetTransaction());

            return result.ToList();
        }
    }
}
