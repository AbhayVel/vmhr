using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{
    [Table("Home")]
    public class Home
    { 
        public int NewApplicant { get; set; }

      public int ActiveVacancy { get; set; }

      

        }
}
