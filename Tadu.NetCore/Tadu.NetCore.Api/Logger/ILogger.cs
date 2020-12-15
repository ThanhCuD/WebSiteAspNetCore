﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadu.NetCore.Api.Logger
{
    public interface ILogger
    {
        void Debug(string text);
        void Warn(string text);
        void Error(string text);
        void Error(string text, Exception ex);
    }
}
