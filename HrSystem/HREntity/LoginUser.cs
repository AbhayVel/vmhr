﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HREntity
{
   public  class LoginUser
   {
      [Key]
      public int Id { get; set; }
      public string Role { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }

   }
}
