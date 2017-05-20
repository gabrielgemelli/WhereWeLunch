using System.Net;

namespace WhereWeLunch.Models.Response
{
    public abstract class ApiResponse
    {
        public bool StatusIsSuccessful { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseResult { get; set; }
    }

    public abstract class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}