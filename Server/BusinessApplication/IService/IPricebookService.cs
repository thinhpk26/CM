using Application.IService;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface IPricebookService : IBaseService<Pricebook, PricebookGetDTO, PricebookInsertDTO, PricebookUpdateDTO>
    {
    }
}
