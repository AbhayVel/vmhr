using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{
   
   public class UserModel : BaseModel
    {

        public override string ColumnName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_columnName))
                {
                    return "UserId";
                }
                return _columnName;
            }

            set
            {

                _columnName = value;
            }
        }


        public string UserIdSearch { get; set; }
      public string NameSearch { get; set; }


        public IEnumerable<T> Where<T>(IEnumerable<T> list) where T : User
        {
            
            if (!string.IsNullOrWhiteSpace(UserIdSearch))
            {
                int value = 0;
                if (Int32.TryParse(UserIdSearch, out value))
                {
                    list = list.Where(x => x.UserId == value);
                }
            }
            if (!string.IsNullOrWhiteSpace(NameSearch))
            {

                list = list.Where(x => x.Name.Contains(NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            return list;
        }

    }
}
