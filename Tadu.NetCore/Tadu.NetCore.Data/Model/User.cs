using Microsoft.AspNetCore.Identity;

namespace Tadu.NetCore.Data.Model
{
    public class User : IdentityUser<int>
    {
        public string City { get; set; }
        public string Token { get; set; }
    }
}
