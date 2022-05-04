using HRDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRRepository
{
    public class FeedTypeRepository
    {
        public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 

        public FeedTypeRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }


    }
}
