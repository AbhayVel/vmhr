using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{
   [Table("Settings")]
   public class Settings
   {
      public string SystemName { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      public string AboutUs { get; set; }
   }
}
