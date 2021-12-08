using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_web_app.Models
{
    [Table("staff_web_app")]
    public class User_details
    {
        [Key]
        [Required(ErrorMessage ="This field is required")]
        public String user_name { get; private set; }
        public String name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public String password { get; set; }
        public String role_id { get; set; }
        public String active_deactive { get; set; }
       
    }
    
}
