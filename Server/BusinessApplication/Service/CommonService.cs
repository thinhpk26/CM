using BusinessApplication.IService;
using BusinessRepo.IRepo;
using BusinessRepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApplication.Service
{
    public class CommonService : ICommonService
    {
        public ICommonRepo Repo;
        public CommonService(ICommonRepo repo)
        {
            Repo = repo;
        }

        public async Task<List<ResponseDictionary>> GetDictionaryByFieldName(string field)
        {
            var result = await Repo.GetDictionaryByFieldName(field);
            return result;
        }

        public async Task<List<GridCell>> GetGridEdit(string layoutCode)
        {
            var result = await Repo.GetGridEdit(layoutCode);
            return result;
        }

        public async Task<List<GroupBox>> GetGroupBoxesByLayoutCode(string layoutCode)
        {
            var result = await Repo.GetGroupBoxesByLayoutCode(layoutCode);
            return result;
        }

        public async Task<List<Layout>> GetLayoutList()
        {
            var result = await Repo.GetLayoutList();
            return result;
        }

    }
}
