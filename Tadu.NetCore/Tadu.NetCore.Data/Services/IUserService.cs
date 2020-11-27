using System;
using System.Collections.Generic;
using System.Text;

namespace Tadu.NetCore.Data.Services
{
    public interface IUserService
    {
        public ApiResult CreateUser(string userName, string password);
        public ApiResult Login(string userName, string password);
    }
}
