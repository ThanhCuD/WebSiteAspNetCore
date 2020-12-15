using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tadu.NetCore.Data.Model
{
    public class TaduDBContext : IdentityDbContext<User,Role,int>
    {
        public TaduDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
