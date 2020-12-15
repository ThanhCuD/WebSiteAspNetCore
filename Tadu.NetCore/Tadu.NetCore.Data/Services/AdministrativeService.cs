using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tadu.NetCore.Data.CustomModel;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Services
{
    public class AdministrativeService : IAdministrativeService
    {
        private readonly RoleManager<Role> roleManager;

        public AdministrativeService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }
            
        public async Task<IdentityResult> CreateRoleAsync(CreateRoleModel model)
        {
            var role = new Role
            {
                Name = model.Name
            };
            var result = await roleManager.CreateAsync(role);
            return result;
        }
        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            var result = await roleManager.Roles.ToListAsync();
            return result;
        }

        public async Task EditRoleAsync(EditRoleModel model)
        {
            var result = await roleManager.FindByIdAsync(model.Id.ToString());
            if(result != null)
            {
                result.Name = model.Name;
                await roleManager.UpdateAsync(result);
            }
        }
    }
}
