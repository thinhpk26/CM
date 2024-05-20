using Application.Service;
using AuthAppication.DTO.CompanyDTO;
using AuthAppication.DTO;
using AuthAppication.IServices;
using Repo.Entities;
using AuthRepo.IRepos;
using AutoMapper;
using Repo.Context;
using Repo.IRepo;
using Repo.UnitOfWork;
using AuthRepo.Models;
using Microsoft.VisualBasic;

namespace AuthAppication.Services
{
    public class CompanyService : BaseService<Company, CompanyGetDTO, CompanyInsertDTO, CompanyUpdateDTO>, ICompanyService
    {
        private readonly ICompanyRepo Repo;
        protected override string LayoutCode => "CompanyCode";
        private readonly IUserPlatFormRepo _userPlatFormRepo;
        public CompanyService(ICompanyRepo repo, IMapper mapper, ICMHttpContext context, IUserPlatFormRepo userPlatFormRepo, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
            _userPlatFormRepo = userPlatFormRepo;
        }

        public async Task<bool> CreateNewCompany(string DbSave)
        {
            return await Repo.CreateNewCompany(DbSave);
        }

        public override async Task AfterInsertEntity(Company company, CompanyInsertDTO companyInsert)
        {
            await _userPlatFormRepo.InserEntities(company.Users);
        }

        public async Task<List<CompanyGetDTO>> GetCompanyByAccountPassword(CompanyByAccountPassword loginInfor)
        {
            var result = await Repo.GetCompanyByAccountPassword(loginInfor);
            
            var companyGets = result.Select(item => Mapper.Map<CompanyGetDTO>(item));
            return companyGets.ToList();
        }

        public async Task<List<CompanyGetDTO>> GetAllCompanyOfUserByUserID(string userID)
        {
            var result = await Repo.GetAllCompanyByUserID(userID);

            var companyGets = result.Select(item => Mapper.Map<CompanyGetDTO>(item));
            return companyGets.ToList();
        }

        public async Task<CompanyGetDTO> GetCompanyByConfirmCode(string confirmCode)
        {
            var result = await Repo.GetCompanyByConfirmCode(confirmCode);
            var companyGet = Mapper.Map<CompanyGetDTO>(result);
            return companyGet;
        }

        public async Task<List<UserPlatForm>> GetUserPlatformByCompanyCode(string companyCode)
        {
            var result = await Repo.GetUserPlatformByCompanyCode(companyCode);
            return result;
        }
    }
}
