using Business;
using Controller.Response;
using Repo.UnitOfWork;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace Controller.Middleware
{
    /// <summary>
    /// Bắt tập trung các exception trong ứng dụng
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            try
            {
                await _next.Invoke(httpContext);
            } catch(Exception ex)
            {
                // Rollback lại dữ liệu
                //await unitOfWork.RollBackAsync();
                // Cấu hình trả về lỗi
                var result = new ResponseResult<object>();
                if(ex.GetType() == typeof(BusinessException))
                {
                    var businessEx = (BusinessException)ex;
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    result.StatusCode = 288;
                    result.Error = businessEx.ErrorMessages;
                } else
                {
                    if (ControllerConfig.Environment == Repo.Enums.CMEnvironment.Production)
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        result.StatusCode = StatusCodes.Status500InternalServerError;
                        result.Error = new List<string>() { "Server" };
                    }
                    else
                    {
                        result.Error = new List<string>() { ex.Message };
                    }
                }
                httpContext.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(httpContext.Response.Body, result);
            }
        }
    }
}
