using Repo.Entities;
using AuthRepo.IRepos;
using AuthRepo.Models;
using Dapper;
using Repo.Repo;
using Repo.UnitOfWork;

namespace AuthRepo.Repos
{
    public class ConfirmCodeRepo : BaseRepo<ConfirmCode>, IConfirmCodeRepo
    {
        public ConfirmCodeRepo(IConfiguration config, IUnitOfWork unitOfWork) : base(config, unitOfWork)
        {
        }

        public async Task<ConfirmCode> GetConfirmCodeByCode(Guid code)
        {
            var query = $"SELECT * FROM {GetTableName()} cc JOIN company c on cc.CompanyID = c.ID WHERE cc.ConfirmCode = @ConfirmCode";

            var param = new DynamicParameters();
            param.Add("ConfirmCode", code);

            var result = await Cnn.QueryAsync<ConfirmCode, Company, ConfirmCode>(query, (confirmCode, company) =>
            {
                confirmCode.Company = company;
                return confirmCode;
            }, param: param, splitOn: "CompanyID", transaction: UnitOfWork.GetTransaction());

            return result.FirstOrDefault();
        }
    }
}
