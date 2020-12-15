using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public interface IAdministrativeService
    {
        public Task<IdentityResult> CreateRoleAsync(CreateRoleModel model);
        public Task<IEnumerable<Role>> GetRoleAsync();
        public Task EditRoleAsync(EditRoleModel model);
    }
}
