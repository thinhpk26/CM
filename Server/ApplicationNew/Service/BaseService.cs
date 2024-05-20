using Application.IService;
using AutoMapper;
using Business;
using Repo.Attributes;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.Models;
using Repo.UnitOfWork;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;
using System.Reflection.Metadata;
using Utility;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Service
{
    public abstract class BaseService<T, TGet, TInsert, TUpdate> : IBaseService<T, TGet, TInsert, TUpdate> where T : BaseEntity
    {
        protected readonly IBaseRepo<T> Repo;
        protected readonly IMapper Mapper;
        protected readonly ICMHttpContext Context;
        protected readonly IUnitOfWork UnitOfWork;

        protected virtual string LayoutCode { get; }

        protected int NumberCode = 0;
        public BaseService(IBaseRepo<T> repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork)
        {
            Repo = repo;
            Mapper = mapper;
            Context = context;
            UnitOfWork = unitOfWork;
        }

        public async Task<TGet> GetEntityByID(long id)
        {
            var result = await Repo.GetEntityByID(id);
            return Mapper.Map<TGet>(result);
        }

        public async Task<List<TGet>> GetListEntities(PagingParameter? pagingParameter)
        {
            var result = await Repo.GetListEntities(pagingParameter);
            var entities = new List<TGet>();
            result.ForEach(entity =>
            {
                entities.Add(Mapper.Map<TGet>(entity));
            });
            return entities;
        }

        public virtual async Task<TGet> InserEntity(TInsert insertEntity)
        {
            try
            {
                await UnitOfWork.OpenAsync();

                await UnitOfWork.BeginTransationAsync();

                await BeforeMappingEntity(insertEntity);
                var entity = await MappingEntityInsertToEntity(insertEntity);
                await BeforeInsertEntity(entity);
                var result = await Repo.InserEntity(entity);
                object code = "";
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    var attr = attrs.FirstOrDefault(item => (item as EntityCodeAttribute) != null);
                    if (attr != null)
                    {
                        code = prop.GetValue(entity);
                    }
                }
                var entityAfterInsert = entity;
                if (code != null && !string.IsNullOrWhiteSpace(code.ToString()))
                {
                    entityAfterInsert = await GetEntityByEntityCode(code.ToString());
                }
                await AfterInsertEntity(entityAfterInsert, insertEntity);

                var entityGet = Mapper.Map<TGet>(entityAfterInsert);

                await UnitOfWork.CommitAsync();
                return entityGet;
            }
            catch (Exception ex)
            {
                await UnitOfWork.RollBackAsync();
                throw ex;
            }
            finally
            {
                await UnitOfWork.CloseAsync();
            }
        }

        /// <summary>
        /// Trước khi mapping entity
        /// </summary>
        /// <returns></returns>
        public virtual async Task BeforeMappingEntity(TInsert entity) { }

        /// <summary>
        /// Trước khi insert entity
        /// </summary>
        /// <returns></returns>
        public virtual async Task BeforeInsertEntity(T entity)
        {
            var user = Context.GetUser();
            entity.CreatedBy = entity.ModifiedBy = user?.FullName;
            entity.CreatedDate = entity.ModifiedDate = DateTimeOffset.Now;
        }

        /// <summary>
        /// Sau khi insert Entity
        /// </summary>
        /// <returns></returns>
        public virtual async Task AfterInsertEntity(T entity, TInsert entityInsert)
        {
            // Lưu trữ lại mã hiện tại
            if (this.NumberCode != 0)
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    var attr = attrs.FirstOrDefault(item => (item as EntityCodeAttribute) != null);
                    if (attr != null)
                    {
                        await Repo.SaveEntityCode(LayoutCode, this.NumberCode);
                    }
                }
            }
        }

        /// <summary>
        /// Mapping từ entity insert thành entity
        /// </summary>
        /// <param name="insertEntity"></param>
        /// <returns></returns>
        public virtual async Task<T> MappingEntityInsertToEntity(TInsert insertEntity)
        {
            var error = new List<string>();
            // Thêm code nếu người dùng không truyền lên
            if (LayoutCode != null)
            {
                foreach (PropertyInfo prop in typeof(TInsert).GetProperties())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    var attr = attrs.FirstOrDefault(item => (item as EntityCodeAttribute) != null);
                    if (attr != null)
                    {
                        // Kiểm tra mã có trùng không
                        var nextCode = prop.GetValue(insertEntity);
                        if (nextCode != null)
                        {
                            var entityExist = await Repo.GetEntityByCode(prop.Name, nextCode.ToString());
                            if (entityExist != null)
                            {
                                error.Add(prop.Name);
                                error.Add(entityExist.ID.ToString());
                                throw new BusinessException(error);
                            }
                        }

                        if (nextCode == null || string.IsNullOrWhiteSpace(nextCode.ToString()))
                        {
                            var tableCode = await Repo.GetTableCode(LayoutCode);
                            if (tableCode != null)
                            {
                                var numberCurr = tableCode.NumberCurrent;
                                do
                                {
                                    nextCode = $"{tableCode.Prefix}{(((decimal)1 / 1000000) * numberCurr).ToString().Substring(2)}";
                                    numberCurr += 1;
                                } while ((await Repo.GetEntityByCode(prop.Name, nextCode.ToString())) != null);
                                this.NumberCode = numberCurr;
                            }
                        }
                        prop.SetValue(insertEntity, nextCode);
                    }
                }
            }
            T entity = Mapper.Map<T>(insertEntity);
            return entity;
        }

        public virtual async Task<int> InsertEntities(List<TInsert> insertEntities)
        {
            await BeforeMappingEntities(insertEntities);
            var entities = insertEntities.Select(async (item) => await MappingEntityInsertToEntity(item)).Select(t => t.Result)
                   .Where(i => i != null)
                   .ToList();
            await BeforeInsertEntities(entities);
            var result = await Repo.InserEntities(entities);
            await AfterInsertEntities(entities);
            return result;
        }

        public virtual async Task BeforeMappingEntities(List<TInsert> insertEntities)
        {

        }


        public virtual async Task BeforeInsertEntities(List<T> insertEntities)
        {

        }

        public virtual async Task AfterInsertEntities(List<T> insertEntities)
        {

        }

        public async Task<bool> UpdateEntitiesByCondition(UpdateParameter updateParameter)
        {
            var result = await Repo.UpdateEntitiesByCondition(updateParameter);
            return true;
        }

        public async Task<bool> UpdateEntity(long id, TUpdate newEntity)
        {
            await BeforeMappingEntityUpdate(id, newEntity);
            var entity = await MappingEntityUpdateToEntity(id, newEntity);
            await BeforeUpdateEntity(id, entity);
            var result = await Repo.UpdateEntityByID(entity);
            await AfterUpdateEntity(entity, id, newEntity);
            return result;
        }

        /// <summary>
        /// Trước khi mapping entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public virtual async Task BeforeMappingEntityUpdate(long id, TUpdate newEntity) { }

        /// <summary>
        /// Trước khi update entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task BeforeUpdateEntity(long id, T entity)
        {
            var user = Context.GetUser();
            entity.CreatedBy = entity.ModifiedBy = user?.FullName;
            entity.CreatedDate = entity.ModifiedDate = DateTimeOffset.Now;
            entity.ID = id;
        }

        /// <summary>
        /// Sau khi update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AfterUpdateEntity(T entity, long id, TUpdate newEntity) { }

        /// <summary>
        /// Mapping entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public virtual async Task<T> MappingEntityUpdateToEntity(long id, TUpdate newEntity)
        {
            var error = new List<string>();
            if (LayoutCode != null)
            {
                foreach (PropertyInfo prop in typeof(TInsert).GetProperties())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    var attr = attrs.FirstOrDefault(item => (item as EntityCodeAttribute) != null);
                    if (attr != null)
                    {
                        // Kiểm tra mã có trùng không
                        var newCode = prop.GetValue(newEntity);
                        if (newCode != null)
                        {
                            var entityExist = await Repo.GetEntityByCode(prop.Name, newCode.ToString());
                            if (entityExist != null && id != entityExist.ID)
                            {
                                error.Add(prop.Name);
                                error.Add(entityExist.ID.ToString());
                                throw new BusinessException(error);
                            }
                        }
                        if (newCode == null || string.IsNullOrWhiteSpace(newCode.ToString()))
                        {
                            error.Add(prop.Name);
                            error.Add("NotEmpty");
                            throw new BusinessException(error);
                        }
                    }
                }
            }
            T entity = Mapper.Map<T>(newEntity);
            return entity;
        }

        public virtual async Task<bool> DeleteEntities(List<long> ids)
        {
            var result = Repo.DeleteEntities(ids);
            return true;
        }

        public Task<bool> DeleteEntity(long id)
        {
            var result = Repo.DeleteEntity(id);
            return result;
        }

        public virtual async Task<PagingSummary> GetSummary(PagingParameter pagingParameter)
        {
            var result = new PagingSummary();
            result.Total = await Repo.GetTotal(pagingParameter);
            return result;
        }

        public async Task<T> GetEntityByEntityCode(string code)
        {
            foreach (PropertyInfo prop in typeof(TInsert).GetProperties())
            {
                object[] attrs = prop.GetCustomAttributes(true);
                var attr = attrs.FirstOrDefault(item => (item as EntityCodeAttribute) != null);
                if (attr != null)
                {
                    return await Repo.GetEntityByEntityCode(prop.Name, code);
                }
            }
            return null;
        }
    }
}
