using Business;
using Controller.Response;
using Microsoft.AspNetCore.Http;
using Repo.UnitOfWork;
using System.Text;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Controller.Middleware
{
    public class DateTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public DateTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Xử lý Khi gửi lên
            await ExecuteRequest(httpContext);
            await _next.Invoke(httpContext);
        }

        private async Task ExecuteRequest(HttpContext httpContext)
        {
            // Đọc dữ liệu từ yêu cầu
            using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                var bodyJSON = await reader.ReadToEndAsync();
                dynamic body = JsonConvert.DeserializeObject(bodyJSON);

                // Chuyển đổi thời gian trong dữ liệu body (vd: JSON)
                ConvertDateTimeToUtc(body);

                // Ghi lại dữ liệu đã chuyển đổi vào yêu cầu
                var byteArray = Encoding.UTF8.GetBytes(body);
                httpContext.Request.Body = new MemoryStream(byteArray);
            }
        }

        private void ConvertDateTimeToUtc(dynamic jsonObject)
        {
            // Duyệt qua các thuộc tính của đối tượng
            foreach (var property in jsonObject)
            {
                // Nếu thuộc tính là kiểu datetime, chuyển đổi thành UTC
                if (property.Value.Type == JTokenType.Date)
                {
                    jsonObject = ((DateTime)property.Value).ToUniversalTime();
                }
                // Nếu thuộc tính là một đối tượng (nested object), đệ quy gọi hàm ConvertDateTimeToUtc
                else if (property.Value is JObject)
                {
                    ConvertDateTimeToUtc((dynamic)property.Value);
                }
                // Nếu thuộc tính là một mảng (array), duyệt qua từng phần tử và gọi hàm ConvertDateTimeToUtc
                else if (property.Value is JArray)
                {
                    foreach (var item in property.Value)
                    {
                        ConvertDateTimeToUtc((dynamic)item);
                    }
                }
            }
        }
    }
}
