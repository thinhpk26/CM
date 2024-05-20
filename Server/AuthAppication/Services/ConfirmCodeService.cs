using Application.Service;
using AuthAppication.DTO.ConfirmCode;
using AuthAppication.IServices;
using Repo.Entities;
using AuthRepo.IRepos;
using AutoMapper;
using Repo.Context;
using Repo.IRepo;
using Repo.UnitOfWork;
using AuthRepo.Repos;
using Business;

namespace AuthAppication.Services
{
    public class ConfirmCodeService : BaseService<ConfirmCode, ConfirmCodeGetDTO, ConfirmCodeInsertDTO, ConfirmCodeUpdateDTO>, IConfirmCodeService
    {
        public readonly ICompanyRepo CompanyRepo;
        public ConfirmCodeService(IConfirmCodeRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork, ICompanyRepo companyRepo) : base(repo, mapper, context, unitOfWork)
        {
            CompanyRepo = companyRepo;
        }

        public async Task<ConfirmCodeGetDTO> CreateConfirmCode(long ID)
        {
            var code = Guid.NewGuid();

            var company = await CompanyRepo.GetEntityByID(ID);

            var error = new List<string>();
            if(company == null)
            {
                error.Add("CreateComfirmCode_company");
                throw new BusinessException(error);
            }

            var confirmCode = new ConfirmCode()
            {
                Company = company,
                Code = code,
                Timeout = 1440,
                IsUsed = false,
                CreateTime = DateTimeOffset.Now,
                CreatedBy = Context.GetUser()?.FullName,
                ModifiedBy = Context.GetUser()?.FullName,
                CreatedDate = DateTimeOffset.Now,
                ModifiedDate = DateTimeOffset.Now,
            };
            await Repo.InserEntity(confirmCode);
            return Mapper.Map<ConfirmCodeGetDTO>(confirmCode);
        }
    }
}
