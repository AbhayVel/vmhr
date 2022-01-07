using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{
   [Table("Login")]
   public class Login
   {


      
      public string UserName { get; set; }
      
      public string Password { get; set; }


   }


   }
