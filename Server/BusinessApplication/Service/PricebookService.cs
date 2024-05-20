using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessRepo.IRepo;
using BusinessRepo.Repo;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.UnitOfWork;

namespace BusinessApplication.Service
{
    public class PricebookService : BaseService<Pricebook, PricebookGetDTO, PricebookInsertDTO, PricebookUpdateDTO>, IPricebookService
    {
        protected override string LayoutCode { get => "Pricebook"; }

        protected readonly IPricebookRepo Repo;
        public PricebookService(IPricebookRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
        }

        public override async Task AfterInsertEntity(Pricebook entity, PricebookInsertDTO pricebookInsert)
        {
            await base.AfterInsertEntity(entity, pricebookInsert);
            var pricebookProductMappingList = pricebookInsert.ProductMapping?.Select(item =>
            {
                item.PricebookID = entity.ID;
                return item;
            }).ToList();
            var result = await Repo.InsertProductMapping(pricebookProductMappingList);
        }

        public override async Task AfterUpdateEntity(Pricebook entity, long id, PricebookUpdateDTO newEntity)
        {
            await base.AfterUpdateEntity(entity, id, newEntity);
            var pricebookProductMappingList = newEntity.ProductMapping?.Select(item =>
            {
                item.PricebookID = entity.ID;
                return item;
            }).ToList();
            var result = await Repo.UpdateProductMapping(id, pricebookProductMappingList);
        }
    }
}
