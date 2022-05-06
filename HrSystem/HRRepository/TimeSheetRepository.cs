using HRDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRRepository
{
    public class TimeSheetRepository
    {
        public HrSystemDBContext HrSystemDBContext { get; set; }

        public TimeSheetRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }
    }
}
