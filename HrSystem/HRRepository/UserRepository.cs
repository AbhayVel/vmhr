﻿using HRDB;
using HREntity;
using HRModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
   public class UserRepository : IUserRepository
   
   {
      public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 


      public UserRepository(HrSystemDBContext hrSystemDBContext)
      {
         HrSystemDBContext = hrSystemDBContext;
      }

      public User Get(int id)
      {

         return HrSystemDBContext.Users.FirstOrDefault(x => x.Id == id);
      }

      public User Save(User user)
      {
         if (user.Id == 0 || user.Id is null)
         {
            HrSystemDBContext.Users.Add(user);
         }
         else
         {
            HrSystemDBContext.Attach(user);
            HrSystemDBContext.Entry(user).State = EntityState.Modified;
         }

         HrSystemDBContext.SaveChanges();

         return user;
      }

      public void Delete(User user)
      {
         HrSystemDBContext.Remove(user);

         HrSystemDBContext.SaveChanges();
      }

      public void Delete(int id)
      {
         var user = Get(id);
         if (!(user is null))
         {
            Delete(user);
         }
      }



      public List<User> GetAll(UserModel userModel, PageModel pageModel)
      {
         string columnName = userModel.ColumnName;
         string orderBy = userModel.OrderBy;

         var lstUser = userModel.Where(HrSystemDBContext.Users);
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