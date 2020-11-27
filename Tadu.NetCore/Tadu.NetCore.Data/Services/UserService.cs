using System.Linq;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly TaduDBContext dBContext;
        public UserService(TaduDBContext context)
        {
            dBContext = context;
        }

        public ApiResult CreateUser(string userName, string password)
        {
            var user = new User()
            {
                UserName = userName,
                Password = password
            };
            dBContext.Users.Add(user);
            dBContext.SaveChanges();
            return new ApiResult()
            {
                Status = ApiResultEnum.Success
            };
        }
        public ApiResult Login(string userName, string password)
        {
            var user = dBContext.Users.FirstOrDefault(_ => _.UserName == userName && _.Password == password);
            if (user != null)
            {
                user.IsLogin = true;
                dBContext.Users.Update(user);
                dBContext.SaveChanges();
                return new ApiResult()
                {
                    Status = ApiResultEnum.Success
                };
            }
            return new ApiResult()
            {
                Status = ApiResultEnum.NothingChange
            };
        }
    }
}
