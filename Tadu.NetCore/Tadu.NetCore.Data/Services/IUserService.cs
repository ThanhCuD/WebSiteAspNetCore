using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public interface IUserService
    {
        public Task<User> GetUserById(string id);
        public Task<IdentityResult> RegisterUserAsync(RegisterUserModel model);
        public Task<User> Login(LoginModel model);
        public  Task Logout();
    }
}
