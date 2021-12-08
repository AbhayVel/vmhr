using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Staff_web_app.Models
{
    [Table("Job_details")]
    public class Job_details
    {

        [Key]
        public String Job_id { get;  set; }
        public String job_description { get; set; }

        public String experince { get; set; }
        public String qualification { get; set; }
        public String primary_skills { get; set; }
        public String secondary_skills { get; set; }
        public String active_deactive { get; set; }
        public String insert_date_time { get; set; }
        public String update_date_time { get; set; }
        public String vacancy { get; set; }
        public String applications { get; set; }
    }
}
