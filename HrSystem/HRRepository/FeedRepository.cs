using HRDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRRepository
{
    public class FeedRepository
    {
        public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 

        public FeedRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }


    }
}
