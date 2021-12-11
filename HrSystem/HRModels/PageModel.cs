using System;
using System.Collections.Generic;
using System.Text;

namespace HRModels
{
 public   class PageModel
    {
        int _currentPage;
        public int CurrentPage { get
            {
                if (_currentPage <= 0)
                {
                    return 1;
                }
                return _currentPage;
            }
            set
            {

                _currentPage = value;
            }
        }
        public int RowPerPage { get; set; }

        public int TotalRowCount { get; set; }

        public int PageCount { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }




    }
}
