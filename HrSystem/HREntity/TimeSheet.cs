using System;
using System.Collections.Generic;
using System.Text;

namespace HREntity
{
    public class TimeSheet
    {
        public string TextData { get; set; }

        public string Heading { get; set; }

        public string ShortNotes { get; set; }

        public float TimeSpend { get; set; }

        public DateTime TaskStartDate { get; set; }

        public DateTime TaskEndDate { get; set; }

        public DateTime TaskDate { get; set; }
    }
}
