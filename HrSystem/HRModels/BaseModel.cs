using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{
    public class BaseModel
    {
        protected string _columnName;

        protected string _orderBy;


        public PageModel PageModel { get; set; }  = new PageModel();

        public virtual string ColumnName
        {
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

        public virtual string OrderBy
        {
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
