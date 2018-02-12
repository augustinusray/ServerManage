using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entitys
{
    public class User : IdentityUser
    {
        [Range(1, 10)]
        public int UserAuthority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
