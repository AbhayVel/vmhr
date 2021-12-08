using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Staff_web_app.Models
{


    

    public class Can_resume
    {
        public String first_name { get; set; }
        public String last_name { get; set; }
        
        public string dob { get; set; }
        public String email { get; set; }
        
        public String status { get; set; }
        public String job_id { get; set; }
        public IFormFile Resume { get; set; }

    }
}
