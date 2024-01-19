using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamApiApp.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        [Required]
        [StringLength(50,MinimumLength =4)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50,MinimumLength =6)]
        public string Password { get; set; }

        public string Role {  get; set; }
    }
}