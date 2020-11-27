using System;
using System.Collections.Generic;
using System.Text;

namespace Tadu.NetCore.Data
{
    public class ApiResult
    {
        public ApiResult()
        {
            Status = ApiResultEnum.NothingChange;
        }
        public void NotFound(string field, int value)
        {
            Message = $"Not found data with {field}: {value}, the data no longer exist or has been deleted";
        }
        public ApiResultEnum Status { get; set; }
        public string Message { get; set; }
    }
    public enum ApiResultEnum
    {
        Success = 1,
        NothingChange = 0,
    }
}
