using System;

namespace HRModels
{
    public class ApplicationModel
    {
        string _columnName;

        string _orderBy;

        public string ColumnName {
           get
            {
                if (string.IsNullOrWhiteSpace(_columnName))
                {
                    return "Id";
                }
                return _columnName;
            }

            set
            {

                _columnName = value;
            }
        }

        public string OrderBy { 
            get
            {
                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "desc";
                }
                return _orderBy;
            }

            set
            {
                _orderBy = value;
            }
        }

    }
}
