using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Staff_web_app.Models
{
    public class User
    {
        public String user_name { get; set; }
        public String password { get; set; }
        public bool RememberMe { get; set; }

    }
}
