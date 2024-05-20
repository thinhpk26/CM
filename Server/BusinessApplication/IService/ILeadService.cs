using Application.IService;
using Application.Service;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface ILeadService : IBaseService<Lead, LeadGetDTO, LeadInsertDTO, LeadUpdateDTO>
    {
        /// <summary>
        /// Chuyển đổi tiềm năng sang khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AccountGetDTO> ConvertAccount(long id);
    }
}
