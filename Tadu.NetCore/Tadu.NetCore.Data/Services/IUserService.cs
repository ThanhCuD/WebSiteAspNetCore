using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<IdentityResult> RegisterUserAsync(RegisterUserModel model);
        Task<User> Login(LoginModel model);
        Task Logout();
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Authen2(AuthenticateRequest model);
    }
}
