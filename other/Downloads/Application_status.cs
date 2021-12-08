using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Staff_web_app.Models
{
    [Table("Application_status")]
    public class Application_status
    {
        
        [Key]
        public String application_id { get; set; }

        public String candidate_id { get; set; }
        public String status { get; set; }
        public String interview_id { get; set; }
        public String job_id { get; set; }
    }
}
