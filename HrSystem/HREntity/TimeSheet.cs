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
        public string TextData { get; set; }

        public string Heading { get; set; }

        public string ShortNotes { get; set; }

        public decimal? TimeSpend { get; set; }

        public DateTime? TaskStartDate { get; set; }

        public DateTime? TaskEndDate { get; set; }

        public DateTime? TaskDate { get; set; }
        
    }
}
