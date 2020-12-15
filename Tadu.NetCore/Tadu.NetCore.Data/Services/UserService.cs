using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(RegisterUserModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            return result;
        }
    }
}
