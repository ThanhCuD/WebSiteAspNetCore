using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;

namespace Tadu.NetCore.Data.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUserAsync(RegisterUserModel model);
        //public ApiResult Login(string userName, string password);
    }
}
