using System;

namespace HRModels
{
    public class VacancyModel
    {
        public readonly dynamic pageModel;
        string _columnName;
        string _orderBy;
        public string columnName {
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
        public string orderBy {
            get
            {

                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "asc";
                }
                return _orderBy;

            }
            set
            {
                _orderBy = value;
            }
        }

        public string IdSearch { get; set; }

        public string PositionSearch { get; set; }
    }
}
