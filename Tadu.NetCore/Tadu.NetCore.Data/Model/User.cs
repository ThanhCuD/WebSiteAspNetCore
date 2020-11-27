using System;
using System.Collections.Generic;
using System.Text;

namespace Tadu.NetCore.Data.Model
{
    public class User
    {
        public User()
        {
            IsLogin = false;
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLogin { get; set; }
    }
}
