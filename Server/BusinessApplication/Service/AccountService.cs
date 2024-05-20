using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Repo.Entities;
using BusinessRepo.IRepo;
using Repo.Context;
using Repo.IRepo;
using Repo.UnitOfWork;

namespace BusinessApplication.Service
{
    public class AccountService : BaseService<Account, AccountGetDTO, AccountInsertDTO, AccountUpdateDTO>, IAccountService
    {
        protected override string LayoutCode { get => "Account"; }
        private readonly IContactService ContactService;
        public AccountService(IAccountRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork, IContactService contactService) : base(repo, mapper, context, unitOfWork)
        {
            ContactService = contactService;
        }

        public async Task<OrderGetDTO> ConvertOrder(long id)
        {
            var account = await Repo.GetEntityByID(id);
            var order = Mapper.Map<OrderGetDTO>(account);
            if(order.AddressShipping == null && account.ContactShippingID != 0)
            {
                var contactShipping = await ContactService.GetEntityByID(account.ContactShippingID);
                order.AddressShipping = contactShipping.Address;
            }
            if (order.AddressInvoice == null && account.ContactInvoiceID != 0)
            {
                var contactInvoice = await ContactService.GetEntityByID(account.ContactInvoiceID);
                order.AddressInvoice = contactInvoice.Address;
            }
            order.ID = 0;
            order.AccountID = account.ID;
            order.AccountName = account.AccountName;
            order.ContactID = account.ContactShippingID;
            order.ContactIDText = account.ContactShippingIDText;
            return order;
        }
    }
}
