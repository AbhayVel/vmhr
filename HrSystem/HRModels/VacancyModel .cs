using System;

namespace HRModels
{
    public class VacancyModel : BaseModel
    {

        public override string OrderBy
        {
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
