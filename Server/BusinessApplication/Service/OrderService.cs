using Application.IService;
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
    public class OrderService : BaseService<Order, OrderGetDTO, OrderInsertDTO, OrderUpdateDTO>, IOrderService
    {
        protected override string LayoutCode { get => "Order"; }

        protected readonly IOrderRepo Repo;
        public OrderService(IOrderRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
        }
        public override async Task AfterInsertEntity(Order entity, OrderInsertDTO productInsert)
        {
            await base.AfterInsertEntity(entity, productInsert);
            var pricebookProductMappingList = productInsert.ProductMapping?.Select(item =>
            {
                item.OrderID = entity.ID;
                return item;
            }).ToList();
            var result = await Repo.InsertProductMapping(pricebookProductMappingList);
        }
    }
}
