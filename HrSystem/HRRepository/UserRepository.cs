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
         /*List<User> lstUser = new List<User>();
         lstUser.Add(new User
         {
            UserId = 1,
            Name = "Abhi",
            UserName = "Admin",
            Action = "Active"
         });
         lstUser.Add(new User
         {
            UserId = 2,
            Name = "Nikita",
            UserName = "Admin2",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 3,
            Name = "Suraj",
            UserName = "Admin4",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 4,
            Name = "Aniket",
            UserName = "Admin3",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 5,
            Name = "xyz",
            UserName = "Admin4",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 6,
            Name = "babc",
            UserName = "Admin5",
            Action = "Active"

         }); lstUser.Add(new User
         {
            UserId = 7,
            Name = "karmveer",
            UserName = "Admin6",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 8,
            Name = "Rohit",
            UserName = "Admin3",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 9,
            Name = "abc",
            UserName = "Admin3",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 10,
            Name = "hit",
            UserName = "Admin3",
            Action = "Active"

         });
         lstUser.Add(new User
         {
            UserId = 11,
            Name = "Rohit",
            UserName = "Admin3",
            Action = "Active"

         });*/
          var  lstUser = userModel.Where(hrSystemDBContext.Users);
            lstUser = userModel.Sort(lstUser);


            if (!(pageModel is null))
         {
                pageModel.SetValues(lstUser.ToList());

                lstUser = lstUser.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();
         }

         return lstUser.ToList();

      }
   }
}