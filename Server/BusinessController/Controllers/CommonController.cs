using BusinessApplication.IService;
using BusinessRepo.Models;
using Controller.Response;
using Microsoft.AspNetCore.Mvc;

namespace BusinessController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        public ICommonService CommonService;
        public CommonController(ICommonService commonService)
        {
            CommonService = commonService;
        }

        [HttpGet("Layout")]
        public async Task<ResponseResult<List<Layout>>> GetLayoutList()
        {
            var result = new ResponseResult<List<Layout>>();

            result.StatusCode = 200;
            result.Data = await CommonService.GetLayoutList();

            return result;
        }

        [HttpGet("Dictionary/{field}")]
        public async Task<ResponseResult<List<ResponseDictionary>>> GetDictionaryByFieldName([FromRoute]string field)
        {
            var result = new ResponseResult<List<ResponseDictionary>>();

            result.StatusCode = 200;
            result.Data = await CommonService.GetDictionaryByFieldName(field);

            return result;
        }

        [HttpGet("GroupBox/{layoutCode}")]
        public async Task<ResponseResult<List<GroupBox>>> GetGroupboxByLayout([FromRoute] string layoutCode)
        {
            var result = new ResponseResult<List<GroupBox>>();

            result.StatusCode = 200;
            result.Data = await CommonService.GetGroupBoxesByLayoutCode(layoutCode);

            return result;
        }

        [HttpGet("GridEdit/{layoutCode}")]
        public async Task<ResponseResult<List<GridCell>>> GetGridEdit([FromRoute] string layoutCode)
        {
            var result = new ResponseResult<List<GridCell>>();

            result.StatusCode = 200;
            result.Data = await CommonService.GetGridEdit(layoutCode);

            return result;
        }
    }
}
