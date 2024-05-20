using BusinessRepo.IRepo;
using MySqlConnector;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.Repo;
using Repo.UnitOfWork;
using System.Data;
using System.Data.Common;

namespace BusinessRepo.Repo
{
    public abstract class BusinessBaseRepo<T> : global::Repo.Repo.BaseRepo<T>, IBusinessBaseRepo<T> where T : BaseEntity
    {
        protected readonly ICMHttpContext Context;

        protected readonly IUnitOfWork UnitOfWork;

        public BusinessBaseRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Context = context;
            var cnnString = "";
            var company = Context.GetCompany();
            if (company != null)
            {
                cnnString = BuildCnnString(company.DBSave);
            }
            Cnn = UnitOfWork.GetConnection(cnnString);
        }
    }
}
