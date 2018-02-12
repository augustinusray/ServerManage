using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public int UserAuthority { get; set; }

        public string Description { get; set; }
    }
}
