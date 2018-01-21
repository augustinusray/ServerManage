using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class ServerList
    {
        public string ServerId { get; set; }

        public string ServerName { get; set; }

        public string ServerPass { get; set; }

        public int ServerAuthority { get; set; }
    }
}
