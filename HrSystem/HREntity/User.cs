using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{

    [Table("Users")]
   public class User
   {
        [Key]
        [Column("Id")]
        public int UserId { get; set; }

        
        public string Name { get; set; }

        public string address { get; set; }

        public string contact { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public byte Type { get; set; }
       
     
        

       

    }
}
