﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tadu.NetCore.Data.CustomModel
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
