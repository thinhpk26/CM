using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessRepo.IRepo;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.UnitOfWork;

namespace BusinessApplication.Service
{
    public class LeadService : BaseService<Lead, LeadGetDTO, LeadInsertDTO, LeadUpdateDTO>, ILeadService
    {
        protected override string LayoutCode { get => "Lead"; }

        protected readonly ILeadRepo Repo;
        private readonly IAccountService AccountService;
        public LeadService(ILeadRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork, IAccountService accountService) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
            AccountService = accountService;
        }

        public async Task<AccountGetDTO> ConvertAccount(long id)
        {
            var lead = await Repo.GetEntityByID(id);
            // Xóa lead => chuyển đổi tiềm năng

            var accountInsertMapping = Mapper.Map<AccountInsertDTO>(lead);

            // Thêm các trường mà lead không có
            accountInsertMapping.AddressInvoice = lead.Address;
            accountInsertMapping.AddressShipping = lead.Address;
            accountInsertMapping.AccountName = lead.LeadName;

            var result = await AccountService.InserEntity(accountInsertMapping);

            await Repo.DeleteEntity(id);

            return result;
        }
    }
}
