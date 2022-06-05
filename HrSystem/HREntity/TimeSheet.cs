using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HREntity
{

    [Table("TimeSheet")]
    public class TimeSheet
    {

        [Key]
        public int? Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="UserName can have max 20 char long")]
        [MaxLength(20, ErrorMessage = "UserName Should 3 character long")]
        public string UserName { get; set; }

        public string Heading { get; set; }

        public string ShortNotes { get; set; }

        public decimal? TimeSpend { get; set; }

        public DateTime? TaskStartDate { get; set; }

        public DateTime? TaskEndDate { get; set; }

        public DateTime TaskDate { get; set; }


    }
}
