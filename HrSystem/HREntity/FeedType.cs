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

        [MaxLength(20, ErrorMessage = "TypeText can have max 20 character")]
        [MinLength(2,ErrorMessage = "TypeText should be 2 character long")]
        [Required]
        public string TypeText { get; set; }
        
    }
}
