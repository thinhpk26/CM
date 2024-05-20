using BusinessRepo.IRepo;
using BusinessRepo.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;
using System.Data.Common;

namespace BusinessRepo.Repo
{
    public class CommonRepo : ICommonRepo
    {
        public IUnitOfWork UnitOfWork;
        public DbConnection Cnn;
        public ICMHttpContext Context;
        public CommonRepo(IUnitOfWork unitOfWork, ICMHttpContext context)
        {
            UnitOfWork = unitOfWork;
            Context = context;
            Cnn = UnitOfWork.GetConnection(UnitOfWork.BuildCnnString(Context.GetCompany().DBSave));
        }

        public async Task<List<ResponseDictionary>> GetDictionaryByFieldName(string fieldName)
        {
            var query = "SELECT DictionaryKey AS ID, FieldName, Text FROM dictionary WHERE FieldName = @FieldName";
            var result = await Cnn.QueryAsync<ResponseDictionary>(query, new { FieldName = fieldName}, UnitOfWork.GetTransaction());
            return result.ToList();
        }

        public async Task<List<GridCell>> GetGridEdit(string layoutCode)
        {
            var query = "SELECT * FROM grid_edit WHERE LayoutCode = @LayoutCode";
            var result = await Cnn.QueryAsync<GridCell>(query, new { LayoutCode = layoutCode }, UnitOfWork.GetTransaction());
            return result.ToList();
        }

        public async Task<List<GroupBox>> GetGroupBoxesByLayoutCode(string layoutCode)
        {
            var queryGroupBox = "SELECT * FROM group_box WHERE LayoutCode = @LayoutCode";
            var groupBoxList = await Cnn.QueryAsync<GroupBox>(queryGroupBox, new {LayoutCode = layoutCode });

            var queryGroupBoxItem = "SELECT * FROM group_box_item WHERE LayoutCode = @LayoutCode";
            var groupBoxItemList = await Cnn.QueryAsync<GroupBoxItem>(queryGroupBoxItem, new { LayoutCode = layoutCode });

            var result = groupBoxList.ToList().Select(item =>
            {
                item.Items = groupBoxItemList.Where(gbi => gbi.GroupBoxKey == item.GroupBoxKey).ToList();
                return item;
            });
            return result.ToList();
        }

        public async Task<List<Layout>> GetLayoutList()
        {
            var query = "SELECT * FROM layout";
            var result = await Cnn.QueryAsync<Layout>(query, transaction: UnitOfWork.GetTransaction());
            return result.ToList();
        }
    }
}
