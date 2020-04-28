using System;
using System.Collections.Generic;

namespace Login.Data
{
    public partial class Login
    {
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        public int? LoginUserId { get; set; }

        public virtual SystemUser LoginUser { get; set; }
    }
}
