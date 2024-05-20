using Application.IService;
using BusinessApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface IAccountService : IBaseService<Account, AccountGetDTO, AccountInsertDTO, AccountUpdateDTO>
    {
        /// <summary>
        /// Chuyển đổi khách hàng thành đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<OrderGetDTO> ConvertOrder(long id);
    }
}
