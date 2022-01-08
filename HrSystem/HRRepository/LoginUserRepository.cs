using HRDB;
using HREntity;
using HRModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRRepository
{
   public class LoginUserRepository
   {

      //public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 




      //public LoginUserRepository(HrSystemDBContext hrSystemDBContext)
      //{
      //   HrSystemDBContext = hrSystemDBContext;
      //}

      //public int TotalRowCount { get; private set; }

      //public List<LoginUser> GetAll(LoginUserModel loginuserModel, PageModel pageModel)
      //{
      //   string ColumnName = LoginUserModel.ColumnName;
      //   string OrderBy = LoginUserModel.OrderBy;
      //   HrSystemDBContext.Count = HrSystemDBContext.Count + 1;
         
      //   var lstLoginUser = loginuserModel.Where(HrSystemDBContext.LoginUser);
      //   lstLoginUser = loginuserModel.Sort(lstLoginUser);

      //   if (!(pageModel is null))
      //   {
      //      pageModel.SetValues(lstLoginUser.ToList());
      //      lstLoginUser = lstLoginUser.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage);
      //   }
      //   return lstLoginUser.ToList();
      //}


      //public IEnumerable<T> SetLoginUser<T>(IEnumerable<T> lstILoginUser) where T : ILoginUsser
      //{
      //   var lstVacanyIds = lstIVacancy.Select(x => x.VacancyId).Distinct().ToList();
      //   HrSystemDBContext.Count = HrSystemDBContext.Count + 1;
      //   var lstLoginUser = HrSystemDBContext.LoginUser.Where(x => lstVacanyIds.Contains(x.Id)).ToList();

      //   foreach (var item in lstILoginUser)
      //   {
      //      item.LoginUser = lstLoginUser.FirstOrDefault(x => x.Id == item.VacancyId);
      //   }

      //   return lstILoginUser;
      //}

   }
}
