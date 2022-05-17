using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{
    [Table("FeedType")]
    public class FeedType
    {
        [Key]
        public int? Id { get; set; }

        public string TypeText { get; set; }
        
    }
}
