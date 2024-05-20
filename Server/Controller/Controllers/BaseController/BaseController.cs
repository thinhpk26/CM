using Application.IService;
using Repo.Models;
using Controller.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controller.Controllers
{
    [ApiController]
    public class BaseController<T, TGet, TInsert, TUpdate> : ControllerBase
    {
        public readonly IBaseService<T, TGet, TInsert, TUpdate> Service;
        public BaseController(IBaseService<T, TGet, TInsert, TUpdate> service)
        {
            Service = service;
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResponseResult<TGet>> GetEntityByID(long id)
        {
            TGet result;
            result = await Service.GetEntityByID(id);
            return new ResponseResult<TGet>((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        [HttpPost("Paging")]
        public async Task<ResponseResult<List<TGet>>> GetListEntitis(PagingParameter? pagingParameter)
        {
            List<TGet> result;
            result = await Service.GetListEntities(pagingParameter);
            return new ResponseResult<List<TGet>>((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult<bool>> InsertEntity(TInsert entity)
        {
            await Service.InserEntity(entity);
            return new ResponseResult<bool>((int)HttpStatusCode.Created, true);
        }

        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ResponseResult<bool>> UpdateEntity(long id, TUpdate entityUpdate)
        {
            bool result;
            result = await Service.UpdateEntity(id, entityUpdate);
            return new ResponseResult<bool>((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Cập nhật bản ghi theo điều kiện
        /// </summary>
        /// <param name="updateParameter"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ResponseResult<bool>> UpdateEntitiesByCondition(UpdateParameter updateParameter)
        {
            bool result;
            result = await Service.UpdateEntitiesByCondition(updateParameter);
            return new ResponseResult<bool>((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResponseResult<bool>> DeleteEntity(long id)
        {
            bool result;
            result = await Service.DeleteEntity(id);
            return new ResponseResult<bool>((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<ResponseResult<bool>> DeleteEntities(List<long> ids)
        {
            bool result;
            result = await Service.DeleteEntities(ids);
            return new ResponseResult<bool>((int)HttpStatusCode.OK, result);
        }

        [HttpPost("Summary")]
        public async Task<ResponseResult<PagingSummary>> GetSummary(PagingParameter pagingParameter)
        {
            var result = await Service.GetSummary(pagingParameter);
            return new ResponseResult<PagingSummary>((int)HttpStatusCode.OK, result);
        }
    }
}
