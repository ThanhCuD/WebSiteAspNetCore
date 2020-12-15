using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tadu.NetCore.Data.CustomModel
{
    public class CreateRoleModel
    {
        [Required]
        public string Name { get; set; }
    }
}
