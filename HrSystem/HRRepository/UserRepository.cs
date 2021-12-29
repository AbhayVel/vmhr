using HRDB;
using HREntity;
using HRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
   public class UserRepository
   {
      HrSystemDBContext hrSystemDBContext = new HrSystemDBContext();
      public UserRepository()
      {

      }
       
   
      public List<User> GetAll(UserModel userModel, PageModel pageModel)
      {
         string columnName = userModel.ColumnName;
         string orderBy= userModel.OrderBy;
       


         var lstUser = userModel.Where(hrSystemDBContext.Users);
         lstUser = userModel.Sort(lstUser);
         if (!(pageModel is null))
         {
            pageModel.SetValues(lstUser.ToList()) ;

                lstUser = lstUser.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();
         }

        


        

         return lstUser.ToList();

      }
   }
}