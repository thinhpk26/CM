using Repo.Entities;
using AuthRepo.IRepos;
using Dapper;
using MySqlConnector;
using Repo.Repo;
using Repo.UnitOfWork;
using System.Data.Common;
using System.Linq;

namespace AuthRepo.Repos
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(IConfiguration config, IUnitOfWork unitOfWork) : base(config, unitOfWork)
        {
        }

        public async Task<int> CreateUserByCommand(string dbSave, User user)
        {
            var insertField = GetInsertFields(user);
            var fields = new List<string>();
            var values = new List<object>();
            foreach (var item in insertField)
            {
                fields.Add(item.Key);
                values.Add($"@{item.Key}");
            }
            var query = $"USE {dbSave}; INSERT INTO User({string.Join(",", fields)}) VALUES ({string.Join(",", values)})";
            var result = 0;
            var cmd = UnitOfWork.GetConnection().CreateCommand();
            cmd.CommandText = query;
            cmd.Transaction = UnitOfWork.GetTransaction();
            foreach (var item in insertField)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = $"@{item.Key}";
                param.Value = item.Value;
                cmd.Parameters.Add(param);
            }
            result = await cmd.ExecuteNonQueryAsync();
            return result;
        }

        public async Task<User> GetUserByAccount(string account, DbConnection otherCnn = null, DbTransaction otherTran = null)
        {
            var query = $"SELECT * FROM {GetTableName()} WHERE Email = @Email";

            var param = new DynamicParameters();
            param.Add("Email", account);

            var cnn = otherCnn ?? Cnn;
            var tran = otherTran ?? UnitOfWork.GetTransaction();

            var result = await cnn.QueryFirstOrDefaultAsync<User>(query, param, tran);
            return result;
        }

        public async Task<User> GetUserByUserPlatformID(long userFlatformID, Company company)
        {
            CnnString = BuildCnnString(company.DBSave);
            var cnn = new MySqlConnection(CnnString);
            var query = $"SELECT * FROM user WHERE UserPlatformID = @UserPlatformID";
            var param = new DynamicParameters();
            param.Add("UserPlatformID", userFlatformID);
            var result = await cnn.QueryFirstOrDefaultAsync<User>(query, param);
            return result;
        }
    }
}
