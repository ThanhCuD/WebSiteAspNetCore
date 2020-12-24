using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly TaduDBContext taduDBContext;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, TaduDBContext taduDBContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.taduDBContext = taduDBContext;
        }
        public async Task<User> Login(LoginModel model)
        {
            var user = await taduDBContext.Users.FirstOrDefaultAsync(_ => _.UserName == model.UserName);
            if (user != null)
            {
                var res = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (res.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("dsadsa123123L:L:L'':");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        { new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                        }),
                        Expires = DateTime.Now.AddDays(1),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);
                    await taduDBContext.SaveChangesAsync();
                }
            }
            return user;
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
        public async Task<User> GetUserById(string id)
        {
            var result = await taduDBContext.Users.FirstOrDefaultAsync(_=>_.Id.ToString() == id);
            return result;
        }
        public async Task Logout() {
            await signInManager.SignOutAsync();
        }

    }
}
