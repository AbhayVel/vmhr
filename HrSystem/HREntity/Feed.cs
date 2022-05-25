using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{

    [Table("Feeds")]
    public class Feed
    {

        [Key]
        public int? Id { get; set; } //Nullable

        [MaxLength(20, ErrorMessage = "TypeText can have max 20 character")]
        [MinLength(2, ErrorMessage = "TypeText should be 2 character long")]
        [Required]
        public string TextData { get; set; }

        public string Heading { get; set; }

        public string ShortNotes { get; set; }

        public int? FeedTypeId { get; set; }

        public string Link { get; set; }


        public string UserName { get; set; }

        public DateTime FeedDate { get; set; }

    }
}
