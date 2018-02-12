using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entitys
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class UserLoginLog
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(256)]
        [Required(ErrorMessage = "{0}不能为空")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(128)]
        public string Ip { get; set; }
    }
}
