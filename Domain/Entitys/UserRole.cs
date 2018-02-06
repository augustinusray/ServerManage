using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entitys
{
    public class UserRole
    {
        [MaxLength(128)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(128)]
        public string UserPass { get; set; }
        [Range(1,10)]
        public int UserAuthority { get; set; }
    }
}
