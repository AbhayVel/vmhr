using System;
using System.ComponentModel.DataAnnotations;

namespace HrSystem.Models
{
   public class Users
   {

      [Key]
      [Required(ErrorMessage = "This field is required")]
      public String role_id { get; set; }
      public String name { get; set; }
      public String user_name { get; private set; }
      public String active_deactive { get; set; }



      [DataType(DataType.Password)]
      [Required(ErrorMessage = "This field is required")]
      public String password { get; set; }
      
      


   }
}
