using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{

    [Table("User")]
   public class User
   {
        [Key]
        
        public int? Id { get; set; }

        
        public string Name { get; set; }

        public string address { get; set; }

        public string contact { get; set; }
      [Required]
        public string UserName { get; set; }
      [Required]
      
        public string Password { get; set; }

      [Required]
        public string Role { get; set; }
       
     
        

   }
}
