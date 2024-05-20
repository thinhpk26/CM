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
    public class LayoutColumnService : BaseService<LayoutColumn, LayoutColumnGetDTO, LayoutColumnInsertDTO, LayoutColumnUpdateDTO>, ILayoutColumnService
    {
        public readonly ILayoutColumnRepo Repo;
        public LayoutColumnService(ILayoutColumnRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
        }

        public async Task<List<LayoutColumnGetDTO>> GetColumnsByLayoutCode(string layoutCode)
        {
            var result = await Repo.GetColumnsByLayoutCode(layoutCode);

            var layoutColumnGetList = result.Select(item => Mapper.Map<LayoutColumnGetDTO>(item)).ToList();

            return layoutColumnGetList;
        }
    }
}
