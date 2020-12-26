using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Tadu.NetCore.Data.Services;

namespace Tadu.NetCore.Api.Custom
{
    public class CustomValidations
    {
        private  readonly IUserService userService;

        public CustomValidations(IUserService userService)
        {
            this.userService = userService;
        }
        public bool ValidateCurrentUser(string authHeader)
        {
            var handler = new JwtSecurityTokenHandler();

            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            string userId = "";
            try
            {
                userId = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            }
            catch (Exception)
            {
                try
                {
                    userId = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
                }
                catch (Exception)
                {
                    throw new Exception("Error in ValidateCurrentUser getting userId");
                }
            }
            var user = userService.GetUserById(userId);

            if (user.Result.Token.Length > 0)
            {
                return user.Result.Token == authHeader;//&& user.Result.IsLoggedIn == true;
            }
            return false;
        }
    }
}
