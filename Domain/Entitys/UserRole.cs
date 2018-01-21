using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class UserRole
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public int UserAuthority { get; set; }
    }
}
