using Dapper;
using MySqlConnector;
using Repo.Attributes;
using Repo.Entities;
using Repo.Enums;
using Repo.IRepo;
using Repo.Models;
using Repo.UnitOfWork;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using static Dapper.SqlMapper;

namespace Repo.Repo
{
    public abstract class BaseRepo<T> : IRepo.IBaseRepo<T> where T : BaseEntity
    {
        protected readonly IConfiguration Config;
        protected string? CnnString = null;
        protected readonly IUnitOfWork UnitOfWork;
        protected DbConnection Cnn;
        public BaseRepo(IConfiguration config, IUnitOfWork unitOfWork)
        {
            Config = config;
            UnitOfWork = unitOfWork;
            Cnn ??= UnitOfWork.GetConnection();
        }

        /// <summary>
        /// Lấy tên bảng của đối tượng
        /// </summary>
        /// <returns></returns>
        public virtual string GetTableName()
        {
            var tableNameAttribute = typeof(T).GetCustomAttributes(true).FirstOrDefault(att => att as TableAttribute != null);
            var tableName = typeof(T).Name;
            if (tableNameAttribute != null)
            {
                var att = tableNameAttribute as TableAttribute;
                tableName = att!.Name;
            }
            return tableName;
        }

        /// <summary>
        /// Lấy tên bảng của đối tượng với dấu nháy => tránh trường hợp bị tên bảng trùng với tên lỗi
        /// </summary>
        /// <returns></returns>
        public virtual string GetTableNameWithComma()
        {
            return $"`{this.GetTableName()}`";
        }

        /// <summary>
        /// Lấy tất cả thuộc tính của đối tượng
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> GetFields(T entity)
        {
            var _dict = new Dictionary<string, object>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                string field = prop.Name;
                foreach (object attr in attrs)
                {
                    ColumnAttribute? columnAttr = attr as ColumnAttribute;
                    if (columnAttr != null)
                    {
                        field = columnAttr.Name;
                        break;
                    }
                }
                _dict.Add(field, prop.GetValue(entity));
            }

            return _dict;
        }

        public virtual async Task<T> GetEntityByID(long id)
        {
            var query = $"SELECT * FROM {GetTableNameWithComma()} WHERE ID = @ID";
            var param = new DynamicParameters();
            param.Add("ID", id);
            var result = await Cnn.QueryFirstOrDefaultAsync<T>(query, param: param, transaction: UnitOfWork.GetTransaction());
            return result;
        }

        public virtual async Task<List<T>> GetListEntities(PagingParameter? pagingParameter)
        {
            var param = new DynamicParameters();
            var query = "";
            if(pagingParameter == null)
            {
                query = $"SELECT * FROM {GetTableNameWithComma()}";
            } else
            {
                var where = " WHERE ";
                if (pagingParameter.PagingCondition != null && pagingParameter.PagingCondition.Count > 0)
                {
                    where += BuildConditions(param, pagingParameter.NestOperator, pagingParameter.PagingCondition);
                }
                else
                {
                    where += " 1=1 ";
                }
                var limit = pagingParameter.Limit != null ? $"LIMIT {pagingParameter.Limit}" : "";
                var offset = pagingParameter.Limit != null ? $"OFFSET {pagingParameter.Skip}" : "";
                var orderby = BuildOrderBy(pagingParameter.OrderBy);
                var orderByString = string.IsNullOrWhiteSpace(orderby) ? "" : $"Order By {orderby}";
                query = $"SELECT * FROM {GetTableNameWithComma()} {where} {orderByString} {limit} {offset}";
            }

            var result = await Cnn.QueryAsync<T>(query, param: param, transaction: UnitOfWork.GetTransaction());
            return result.ToList();
        }

        public async Task<List<T>> GetListEntities(DbConnection cnn, DbTransaction tran, PagingParameter? pagingParameter)
        {
            var param = new DynamicParameters();
            var query = "";
            if (pagingParameter == null)
            {
                query = $"SELECT * FROM {GetTableNameWithComma()}";
            }
            else
            {
                var where = " WHERE ";
                if (pagingParameter.PagingCondition != null && pagingParameter.PagingCondition.Count > 0)
                {
                    where += BuildConditions(param, pagingParameter.NestOperator, pagingParameter.PagingCondition);
                }
                else
                {
                    where += " 1=1 ";
                }
                var limit = pagingParameter.Limit != null ? $"LIMIT {pagingParameter.Limit}" : "";
                var offset = pagingParameter.Limit != null ? $"OFFSET {pagingParameter.Skip}" : "";
                var orderby = BuildOrderBy(pagingParameter.OrderBy);
                var orderByString = string.IsNullOrWhiteSpace(orderby) ? "" : $"OrderBy {orderby}";
                query = $"SELECT * FROM {GetTableNameWithComma()} {where} {orderByString} {limit} {offset}";
            }

            var result = await cnn.QueryAsync<T>(query, param: param, transaction: tran);
            return result.ToList();
        }

        /// <summary>
        /// Build danh sách condition
        /// </summary>
        /// <param name="op"></param>
        /// <param name="cdt"></param>
        /// <returns></returns>
        public virtual string BuildConditions(DynamicParameters param, NestOperator? no, List<Condition> cdts)
        {
            var sb = new StringBuilder();
            sb.Append("(");
            var opConnect = no == NestOperator.AND ? "AND" : "OR";
            for(int i=0; i<cdts.Count; i++)
            {
                var cdt = cdts[i];
                string condition = "";
                // Trường hợp build key, value
                if (!string.IsNullOrWhiteSpace(cdt.Key))
                {
                    condition = BuildEachCondition(param, cdt.Key, cdt.Value, cdt.Operator);
                }
                // Trường hợp build nestCondition
                if (string.IsNullOrWhiteSpace(condition) && cdt.NestCondition != null && cdt.NestCondition.Count > 0)
                {
                    condition = BuildConditions(param, cdt.NestOperator, cdt.NestCondition);
                }
                if (condition == "")
                {
                    throw new Exception($"BaseRepo BuildConditions: condition = {JsonSerializer.Serialize(cdt)}" );
                }
                sb.Append(condition);
                if (i != cdts.Count - 1)
                {
                    sb.Append($" {opConnect} ");
                }
            }
            sb.Append(")");
            return sb.ToString();
        }


        public virtual string BuildEachCondition(DynamicParameters param, string key, object? value, Operator? op)
        {
            if (op == null)
            {
                throw new Exception($"BaseRepo BuildConditions: key = {key}, value = {value}, operator = {op}");
            }
            string condition;
            switch(op)
            {
                case Operator.Null:
                    condition = $"{key} IS NULL";
                    break;
                case Operator.NotNull:
                    condition = $"{key} IS NOT NULL";
                    break;
                case Operator.NotLike:
                    condition = $"{key} NOT LIKE @{key}";
                    param.Add(key, $"%{value}%");
                    break;
                case Operator.Like:
                    condition = $"{key} LIKE @{key}";
                    param.Add(key, $"%{value}%");
                    break;
                case Operator.As:
                    condition = $"{key} = @{key}";
                    param.Add(key, $"{value}");
                    break;
                case Operator.NotAs:
                    condition = $"{key} <> @{key}";
                    param.Add(key, $"{value}");
                    break;
                default:
                    throw new Exception("operator không chính xác");
            }
            return condition;
        }

        public virtual string BuildOrderBy(List<OrderBy> orderbys)
        {
            if(orderbys == null || orderbys.Count == 0)
            {
                return "";
            }
            var orderStringList = new List<string>();
            foreach(var ob in orderbys)
            {
                var orderString = ob.Order == OrderPaging.Ascending ? "ASC" : "DESC";
                orderStringList.Add($"{ob.Field} {orderString}");
            }
            return string.Join(",", orderStringList);
        }

        public virtual async Task<int> InserEntity(T entity)
        {
            var insertField = GetInsertFields(entity);
            var fields = new List<string>();
            var values = new List<string>();
            ICollection<KeyValuePair<string, object>> param = new ExpandoObject();
            foreach (var item in insertField)
            {
                fields.Add(item.Key);
                var paramKey = $"@{item.Key}";
                values.Add(paramKey);
                param.Add(new KeyValuePair<string, object>(item.Key, item.Value));
            }
            var query = $"INSERT INTO {GetTableNameWithComma()}({string.Join(", ", fields)}) " +
                $" VALUES ({string.Join(", ", values)})";
            var result = await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());
            return result;
        }

        public virtual async Task<int> InserEntity(DbConnection cnn, DbTransaction tran, T entity)
        {
            var insertField = GetInsertFields(entity);
            var fields = new List<string>();
            var values = new List<string>();
            ICollection<KeyValuePair<string, object>> param = new ExpandoObject();
            foreach (var item in insertField)
            {
                fields.Add(item.Key);
                var paramKey = $"@{item.Key}";
                values.Add(paramKey);
                param.Add(new KeyValuePair<string, object>(item.Key, item.Value));
            }
            var query = $"INSERT INTO {GetTableNameWithComma()}({string.Join(", ", fields)}) " +
                $" VALUES ({string.Join(", ", values)})";
            var result = await cnn.ExecuteAsync(query, param, tran);
            return result;
        }

        public virtual async Task<int> InserEntities(List<T> entity)
        {
            if(entity.Count == 0)
            {
                throw new Exception("BaseRepo InserEntities: entity");
            }
            var insertField = GetInsertFields(entity[0]);
            var fields = new List<string>();
            var values = new List<string>();
            foreach (var item in insertField)
            {
                fields.Add(item.Key);
                var paramKey = $"@{item.Key}";
                values.Add(paramKey);
            }
            var query = $"INSERT INTO {GetTableNameWithComma()}({string.Join(", ", fields)}) " +
                $" VALUES ({string.Join(", ", values)})";
            var result = await Cnn.ExecuteAsync(query, entity, UnitOfWork.GetTransaction());
            return result;
        }

        /// <summary>
        /// Lấy các trường insert
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="attrRemove">Những attribute thêm vào để không chọn những thuộc tính đó</param>
        /// <returns></returns>
        public virtual Dictionary<string, object> GetInsertFields(T entity)
        {
            var _dict = new Dictionary<string, object>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                object value = prop.GetValue(entity);

                var noInsert = attrs.FirstOrDefault(attr => attr as NoInsertAttribute != null);
                // Nếu có attribute no insert => loại bỏ trường đó
                if (noInsert == null)
                {
                    // Nếu có attribute mapping sang entity => chạy vòng for để mapping từng trường
                    var insertMapping = attrs.FirstOrDefault(attr => attr as ForeignEntityAttribute != null || attr as InsertFieldAttribute != null);
                    if(insertMapping == null)
                    {
                        string field = prop.Name;

                        // Lấy tên của column
                        var columnAttr = attrs.FirstOrDefault(attr => attr as ColumnAttribute != null) as ColumnAttribute;
                        if (columnAttr != null)
                        {
                            field = columnAttr.Name;
                        }
                        _dict.Add(field, value);
                    } else
                    {
                        foreach (object attr in attrs)
                        {
                            string field = prop.Name;

                            // mapping foreign key
                            var foreignAttr = attr as ForeignEntityAttribute;
                            if (foreignAttr != null)
                            {
                                field = foreignAttr.FieldActual;
                                var fieldNameEntity = foreignAttr.FieldEntity;
                                var fieldValueEntity = prop.GetValue(entity);
                                var fieldEntity = fieldValueEntity.GetType().GetProperty(fieldNameEntity);
                                value = fieldEntity.GetValue(fieldValueEntity);
                                _dict.Add(field, value);
                            }

                            // mapping từ đối tượng code => db
                            var insertFieldAttr = attr as InsertFieldAttribute;
                            if (insertFieldAttr != null)
                            {
                                field = insertFieldAttr.FieldActual;
                                var fieldNameEntity = insertFieldAttr.FieldEntity;
                                var fieldValueEntity = prop.GetValue(entity);
                                var fieldEntity = fieldValueEntity.GetType().GetProperty(fieldNameEntity);
                                value = fieldEntity.GetValue(fieldValueEntity);
                                _dict.Add(field, value);
                            }
                        }
                    }
                }
            }

            return _dict;
        }

        public virtual async Task<int> UpdateEntitiesByCondition(UpdateParameter updateParameter)
        {
            var param = new DynamicParameters();
            var where = "WHERE ";
            if (updateParameter.Condition != null && updateParameter.Condition.Count > 0)
            {
                where += BuildConditions(param, updateParameter.NestOperator, updateParameter.Condition);
            } else
            {
                where += "1=1";
            }
            var updateList = new List<string>();
            foreach(var item in updateParameter.EntityUpdate)
            {
                var paramKey = $"@{item.Key}_Update";
                updateList.Add($"{item.Key} = {paramKey}");
                param.Add(paramKey, item.Value);
            }
            var query = $"UPDATE {GetTableNameWithComma()} SET {string.Join(", ", updateList)} {where}";
            var result = await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());
            return result;
        }

        public virtual async Task<bool> UpdateEntityByID(T newEntity)
        {
            var updateField = GetUpdateFields(newEntity);
            var updateList = new List<string>();
            var param = new DynamicParameters();
            foreach (var item in updateField)
            {
                var paramKey = $"@{item.Key}_Update";
                updateList.Add($"{item.Key} = {paramKey}");
                param.Add(paramKey, item.Value);
            }
            param.Add("ID", newEntity.ID);
            var query = $"UPDATE {GetTableNameWithComma()} SET {string.Join(", ", updateList)} WHERE ID = @ID";
            await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());
            return true;
        }

        /// <summary>
        /// Lấy các trường insert
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="attrRemove">Những attribute thêm vào để không chọn những thuộc tính đó</param>
        /// <returns></returns>
        public virtual Dictionary<string, object> GetUpdateFields(T entity)
        {
            var _dict = new Dictionary<string, object>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                string field = prop.Name;
                var isAllowInsert = true;
                foreach (object attr in attrs)
                {
                    NoUpdateAttribute? noInsertAttr = attr as NoUpdateAttribute;
                    if (noInsertAttr != null)
                    {
                        isAllowInsert = false;
                    }
                    ColumnAttribute? columnAttr = attr as ColumnAttribute;
                    if (columnAttr != null)
                    {
                        field = columnAttr.Name;
                        break;
                    }
                }
                if (isAllowInsert)
                {
                    _dict.Add(field, prop.GetValue(entity));
                }
            }

            return _dict;
        }

        public virtual async Task<int> DeleteEntities(List<long> ids)
        {
            var query = $"DELETE FROM {GetTableNameWithComma()} WHERE ID IN @IDs";
            var param = new DynamicParameters();
            param.Add("IDs", ids.ToArray());
            var result = await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());
            return result;
        }

        public virtual async Task<bool> DeleteEntity(long id)
        {
            var query = $"DELETE FROM {GetTableNameWithComma()} WHERE ID = @ID";
            var param = new DynamicParameters();
            param.Add("ID", id);
            await Cnn.ExecuteAsync(query, param, UnitOfWork.GetTransaction());
            return true;
        }

        public string BuildCnnString(string dbSave)
        {
            return $"server=127.0.0.1;port=3306;database={dbSave};uid=nvthinh1;password=Thinh&thinhhj1;Allow User Variables=True;IgnoreCommandTransaction=true";
        }

        public virtual async Task<long> GetTotal(PagingParameter pagingParameter)
        {
            var param = new DynamicParameters();
            var where = " WHERE ";
            if(pagingParameter.PagingCondition != null && pagingParameter.PagingCondition.Count > 0)
            {
                where += BuildConditions(param, pagingParameter.NestOperator, pagingParameter.PagingCondition);
            } else
            {
                where += " 1=1 ";
            }
            var query = $"SELECT COUNT(*) FROM {GetTableNameWithComma()} {where}";

            var result = await Cnn.ExecuteScalarAsync<long>(query, param: param
                , UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<TableCode> GetTableCode(string layoutCode)
        {
            var query = $"SELECT * FROM table_code WHERE LayoutCode = @LayoutCode";
            var result = await Cnn.QueryFirstOrDefaultAsync<TableCode>(query, new { LayoutCode = layoutCode }, UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<T> GetEntityByCode(string fieldCode, string code)
        {
            var query = $"SELECT * FROM {GetTableNameWithComma()} WHERE {fieldCode} = @FieldCode";
            var result = await Cnn.QueryFirstOrDefaultAsync<T>(query, new { FieldCode = code }, transaction: UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<int> SaveEntityCode(string layoutCode, int number)
        {
            var query = $"Update table_code SET NumberCurrent = @NumberCurrent WHERE LayoutCode = @LayoutCode";
            var result = await Cnn.ExecuteAsync(query, new { NumberCurrent = number, LayoutCode = layoutCode }, UnitOfWork.GetTransaction());
            return result;
        }

        public async Task<T> GetEntityByEntityCode(string fieldCode, string code)
        {
            var query = $"SELECT * FROM {GetTableNameWithComma()} WHERE {fieldCode} = @Code";
            var param = new DynamicParameters();
            param.Add("Code", code);
            var result = await Cnn.QueryFirstOrDefaultAsync<T>(query, param: param, transaction: UnitOfWork.GetTransaction());
            return result;
        }
    }
}
