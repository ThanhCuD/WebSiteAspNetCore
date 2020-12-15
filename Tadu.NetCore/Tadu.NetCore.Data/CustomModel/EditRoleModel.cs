using System.ComponentModel.DataAnnotations;

namespace Tadu.NetCore.Data.CustomModel
{
    public class EditRoleModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
