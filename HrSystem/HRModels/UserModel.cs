using System;
using System.Collections.Generic;
using System.Text;

namespace HRModels
{
   
   public class UserModel
   {
      string _ColumnName;
      string _OrderBy;
      public string ColumnName {
         get
         {
            if(string.IsNullOrWhiteSpace(_ColumnName))
            {
               return "UserId";
            }
           return _ColumnName;
         }
         
         
         
         set
         {
            _ColumnName = value;
         } 
      }

      public string OrderBy {
         get
         {
            if (string.IsNullOrWhiteSpace(_OrderBy))
            {
               return "desc";
            }
            return _OrderBy;
         }
         set
         {
            _OrderBy = value;
         }
      }
      public string UserIdSearch { get; set; }
      public string NameSearch { get; set; }
   }
}
