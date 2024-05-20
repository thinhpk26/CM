using BusinessRepo.IRepo;
using BusinessRepo.Models;
using Dapper;
using Repo.Context;
using Repo.Entities;
using Repo.Models;
using Repo.UnitOfWork;
using System.Data;
using System.Security.Cryptography.Xml;
using System.Security.Principal;

namespace BusinessRepo.Repo
{
    public class ProductRepo : BusinessBaseRepo<Product>, IProductRepo
    {
        public ProductRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }

        public async Task<List<ProductApplyPricebook>> ProductApplyPricebook(string? id)
        {
            var param = new DynamicParameters();
            var employee = Context.GetUser();
            if(employee != null)
            {
                param.Add("v_employee", employee.ID);
            } else
            {
                param.Add("v_employee", null);
            }
            param.Add("v_account", id);
            var proc = "Proc_ProductApplyPricebook";
            var result = await Cnn.QueryAsync<ProductApplyPricebook>(proc, param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
