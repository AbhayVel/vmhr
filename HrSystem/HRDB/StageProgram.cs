using HREntity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRDB
{
   public static class  StageProgram
    {

        public static async Task<List<Stage>> GetStageAsync(this HrSystemDBContext hrdb, int? id)
        {
            List<SqlParameter> lst = new List<SqlParameter>();
          
            if (id == null)
            {

            }
            else
            {
                SqlParameter s = new SqlParameter("@Id", id.Value);
                lst.Add(s);
            }


          var lstStage =   await hrdb.Stages.FromSqlRaw<Stage>("GetStage @Id", lst.ToArray()).ToListAsync();
            return lstStage;
        }


         


    }
}
