using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Staff_web_app.Models
{
    public class Reg_user
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string confirm { get; set; }

    }
}
