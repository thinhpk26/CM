using BusinessRepo.IRepo;
using Dapper;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;

namespace BusinessRepo.Repo
{
    public class LayoutColumnRepo : BusinessBaseRepo<LayoutColumn>, ILayoutColumnRepo
    {
        public LayoutColumnRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }

        public async Task<List<LayoutColumn>> GetColumnsByLayoutCode(string layoutCode)
        {
            var query = $"SELECT * FROM {GetTableName()} WHERE LayoutCode = @LayoutCode";
            var param = new DynamicParameters();
            param.Add("LayoutCode", layoutCode);

            var result = await Cnn.QueryAsync<LayoutColumn>(query, param);
            return result.ToList();
        }
    }
}
