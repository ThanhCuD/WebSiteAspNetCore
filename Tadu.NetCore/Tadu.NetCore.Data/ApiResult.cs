using System;
using System.Collections.Generic;
using System.Text;

namespace Tadu.NetCore.Data
{
    public class ApiResult
    {
        public ApiResult()
        {

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
