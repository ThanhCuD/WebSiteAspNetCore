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
    }
}
