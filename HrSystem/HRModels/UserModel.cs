using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{
   
   public class UserModel : BaseModel
    {
      

      public string UserIdSearch { get; set; }
      public string NameSearch { get; set; }


      public IEnumerable<T> Where<T>(IEnumerable<T> list) where T : User
      {
         UserModel userModel = this;
         if (!string.IsNullOrWhiteSpace(this.UserIdSearch))
         {
            int value = 0;
            if (Int32.TryParse(userModel.UserIdSearch, out value))
            {
               list = list.Where(x => x.UserId == value);
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
         if ("name".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
         {
            if (OrderBy.Equals("asc"))
            {
               list = list.OrderBy(x => x.Name);
            }
            else
            {
               list = list.OrderByDescending(x => x.Name);
            }
         }

         if ("id".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
         {
            if (OrderBy.Equals("asc"))
            {
               list = list.OrderBy(x => x.UserId);
            }
            else
            {
               list = list.OrderByDescending(x => x.UserId);
            }
         }
         return list;
        }

    }
}
