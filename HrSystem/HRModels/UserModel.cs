using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{

    public class UserModel : BaseModel
    {


        public string IdSearch { get; set; }
        public string NameSearch { get; set; }


        public IEnumerable<T> Where<T>(IEnumerable<T> list) where T : User
        {
            UserModel userModel = this;
            if (!string.IsNullOrWhiteSpace(this.IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(userModel.IdSearch, out value))
                {
                    list = list.Where(x => x.Id == value);
                }
            }

            if (!string.IsNullOrWhiteSpace(NameSearch))
            {

                list = list.Where(x => x.Name.Contains(userModel.NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            return list;
        }


        public IEnumerable<T> Sort<T>(IEnumerable<T> list) where T : User
        {
            if ("UserId".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(X => X.Id);
                }
                else
                {
                    list = list.OrderByDescending(X => X.Id);
                }
            }
            if ("Name".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(X => X.Name).ToList();
                }
                else
                {
                    list = list.OrderByDescending(X => X.Name).ToList();
                }
            }
            return list;
        }

    }



    }
