using System;
using System.Collections.Generic;
using System.Text;

namespace HRModels
{
    public class TimeSheetModel
    {
        public string OrderBy { get; set; }

        public string OrderType { get; set; }

        public string IdSearch { get; set; }

        public string TextDataSearch { get; set; }
        public string TimeSpendSearch { get; set; }
        public string ShortNotesSearch { get; set; }
    }
}
