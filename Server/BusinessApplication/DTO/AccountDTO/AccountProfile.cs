using AutoMapper;
using Repo.Context;
using Repo.Entities;

namespace BusinessApplication.DTO.AccountDTO
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountGetDTO>();
            CreateMap<AccountInsertDTO, Account>();
            CreateMap<AccountUpdateDTO, Account>();
            CreateMap<Account, OrderGetDTO>();
        }
    }
}
