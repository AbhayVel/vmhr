using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Staff_web_app.Models
{



    [Table("interview_id")]
    public class interview_ids
    {
        [Key]
        public String interview_id { get; set; }

    
        public DateTime? date_time { get; set; }
        public String application_id { get; set; }
        public String status { get; set; }

        public string duration { get; set; }

    }
}
