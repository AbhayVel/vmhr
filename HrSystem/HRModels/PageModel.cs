using System;
using System.Collections.Generic;
using System.Text;

namespace HRModels
{
    public class PageModel
    {
        int _currentPage;
        public int CurrentPage
        {
            get
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
        public int RowPerPage { get; set; } = 2;

        public int TotalRowCount { get; set; }

        public int PageCount { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }


        public string SetValues(int RowCount)
        {
            PageModel pageModel = this;
            pageModel.TotalRowCount = RowCount;
            int pageCount = (int)Math.Ceiling(pageModel.TotalRowCount * 1.0 / pageModel.RowPerPage * 1.0);
            if (pageModel.CurrentPage > pageCount)
            {
                pageModel.CurrentPage = 1;
            }
            int startIndex = (pageModel.CurrentPage - 1) * pageModel.RowPerPage;
            if (startIndex > pageModel.TotalRowCount - 1)
            {
                startIndex = 0;
            }
            int endIndex = startIndex + pageModel.RowPerPage - 1;

            if (endIndex > pageModel.TotalRowCount - 1)
            {
                endIndex = pageModel.TotalRowCount - 1;
            }
            pageModel.StartIndex = startIndex;
            pageModel.PageCount = pageCount;
            pageModel.EndIndex = endIndex;

            return $"  offset {startIndex} rows fetch next {pageModel.RowPerPage} rows only  ";
        }


        public void SetValues<T>(List<T> data)
        {
            PageModel pageModel = this;
            pageModel.TotalRowCount = data.Count;
            int pageCount = (int)Math.Ceiling(pageModel.TotalRowCount * 1.0 / pageModel.RowPerPage * 1.0);
            if (pageModel.CurrentPage > pageCount)
            {
                pageModel.CurrentPage = 1;
            }
            int startIndex = (pageModel.CurrentPage - 1) * pageModel.RowPerPage;
            if (startIndex > pageModel.TotalRowCount - 1)
            {
                startIndex = 0;
            }
            int endIndex = startIndex + pageModel.RowPerPage - 1;

            if (endIndex > pageModel.TotalRowCount - 1)
            {
                endIndex = pageModel.TotalRowCount - 1;
            }
            pageModel.StartIndex = startIndex;
            pageModel.PageCount = pageCount;
            pageModel.EndIndex = endIndex;
        }

    }



}

