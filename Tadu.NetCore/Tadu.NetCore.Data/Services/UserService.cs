using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password,model.RememberMe,false);
            return result;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUserModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            return result;
        }
        //public async Task<IdentityResult> UpdateUserAsync(UpdateUserModel model)
        //{
        //    var user = await userManager.FindByEmailAsync(model.Email);

        //    await userManager.UpdateAsync(user, model.Password);
        //}
        public async Task Logout() {
            await signInManager.SignOutAsync();
        }

    }
}
