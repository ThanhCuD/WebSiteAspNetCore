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
using Microsoft.Extensions.Options;
using Tadu.NetCore.Global.Helper;

namespace Tadu.NetCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly TaduDBContext taduDBContext;
        private readonly AppSettings _appSettings;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, TaduDBContext taduDBContext, IOptions<AppSettings> options)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.taduDBContext = taduDBContext;
            _appSettings = options.Value;
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
                    var lstRoleId = taduDBContext.UserRoles.Where(_ => _.UserId == user.Id).Select(_=>_.RoleId).ToList();
                    var roles = taduDBContext.Roles.Where(_ => lstRoleId.Contains(_.Id));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        { new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Name, user.Id.ToString())
                            
                        }),
                        Expires = DateTime.Now.AddDays(1),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    foreach (var item in roles)
                    {
                        tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, item.Name));
                    }

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);
                    await taduDBContext.SaveChangesAsync();
                }
                return user;
            }
            return null;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUserModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            return result;
        }
        
        public async Task<User> GetUserById(string id)
        {
            var result = await taduDBContext.Users.FirstOrDefaultAsync(_=>_.Id.ToString() == id);
            return result;
        }
        public async Task Logout() {
            await signInManager.SignOutAsync();
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = userManager.Users.FirstOrDefault(_ => _.UserName == model.Username);
            if (user != null)
            {
                var res = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (res.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    var token = generateJwtToken(user);

                    return new AuthenticateResponse(user, token);
                }
            }
            return null;
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
