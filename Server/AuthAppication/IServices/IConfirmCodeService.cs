using Application.IService;
using AuthAppication.DTO.ConfirmCode;
using Repo.Entities;

namespace AuthAppication.IServices
{
    public interface IConfirmCodeService : IBaseService<ConfirmCode, ConfirmCodeGetDTO, ConfirmCodeInsertDTO, ConfirmCodeUpdateDTO>
    {
        /// <summary>
        /// Tạo confirmCode
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Task<ConfirmCodeGetDTO> CreateConfirmCode(long ID);
    }
}
