using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Staff_web_app.Models
{
    

    

    public class Candidate_details
    {

        string time = DateTime.Now.ToString();

         [Key]
        public String candidate_id { get; set; }
        
        public String first_name { get; set; }
        public String last_name { get; set; }
        
        public string dob { get; set; }
        public String email { get; set; }
        public String resume_path { get; set; }
        public String status { get; set; }
        public String job_id { get; set; }

    }
}
