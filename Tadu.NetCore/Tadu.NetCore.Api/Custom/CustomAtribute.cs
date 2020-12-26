using System;

namespace Tadu.NetCore.Api.Custom
{
    public class CustomAttribute : Attribute
    {
        private string _authHeader;
        public string AuthHeader
        {
            get { return string.Empty; }
            set
            {
                _authHeader = value;
            }
        }
    }
}
