using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ServerListDTO
    {
        public string ServerId { get; set; }

        public string ServerName { get; set; }

        public int ServerAuthority { get; set; }

        public string Description { get; set; }
    }
}
