using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{
    [Table("Stage")]
    public class Stage
    {   [Key]
        public int Id { get; set; }


        public string StatusLabel { get; set; }

        public int? Status { get; set; }

       
    }
}
