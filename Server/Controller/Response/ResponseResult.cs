using System.Net;

namespace Controller.Response
{
    public class ResponseResult<T>
    {
        public ResponseResult(int statusCode, T? data, List<string>? error)
        {
            StatusCode = statusCode;
            Data = data;
            Error = error;
        }

        public ResponseResult(int statusCode, List<string>? error)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public ResponseResult(int statusCode, T? data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public ResponseResult()
        {
        }

        /// <summary>
        /// Status Code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Dữ liệu
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Lỗi
        /// </summary>
        public List<string>? Error { get; set; }
    }
}
