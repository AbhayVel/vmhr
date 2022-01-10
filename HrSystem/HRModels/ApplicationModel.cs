using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRModels
{
    public class ApplicationModel : BaseModel
    {
        public string IdSearch { get; set; }

        public string NameSearch { get; set; }

        public string AppliedForSearch { get; set; }

        public string StageStatusSearch { get; set; }

        public List<Application> Applications { get; set; }


        public string Where() 
        {
            string where = "";
            ApplicationModel applicationModel = this;
            if (!string.IsNullOrWhiteSpace(this.IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(applicationModel.IdSearch, out value))
                {
                    where = $"{where} and  a.Id ={value}";
                    //list = list.Where(x => x.Id == value);
                }
            }

            if (!string.IsNullOrWhiteSpace(NameSearch))
            {
                where = $"{where} and  a.FirstName  like '{NameSearch.Replace("'","''")}'";
                //list = list.Where(x => x.FirstName.Contains(applicationModel.NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrWhiteSpace(AppliedForSearch))
            {

                where = $"{where} and v.Position  like '{AppliedForSearch.Replace("'", "''")}'";
                // list = list.Where(x => x.Vacancy.Position.Contains(applicationModel.AppliedForSearch, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrWhiteSpace(StageStatusSearch))
            {
                where = $"{where} and s.StatusLabel  like '{StageStatusSearch.Replace("'", "''")}'";
                //  list = list.Where(x => x.Stage.StatusLabel.Contains(applicationModel.StageStatusSearch, StringComparison.OrdinalIgnoreCase));

            }

            return " " + where + " ";

        }



        public string Sort()
        {
            string orderBy = "";
            if ("name".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    orderBy = "a.FirstName asc";
                }
                else
                {
                    orderBy = "a.FirstName desc";
                }
            }

            if ("id".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    orderBy = "a.id asc";
                }
                else
                {
                    orderBy = "a.id desc";
                }
            }

            return "   order by " +  orderBy +" ";
        }


        public IEnumerable<T> Where<T>(IEnumerable<T> list) where T : Application
        {
            ApplicationModel applicationModel = this;
            if (!string.IsNullOrWhiteSpace(this.IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(applicationModel.IdSearch, out value))
                {                   
                    list = list.Where(x => x.Id == value);
                }
            }

            if (!string.IsNullOrWhiteSpace(NameSearch))
            {

                list = list.Where(x => x.FirstName.Contains(applicationModel.NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrWhiteSpace(AppliedForSearch))
            {

                list = list.Where(x => x.Vacancy.Position.Contains(applicationModel.AppliedForSearch, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrWhiteSpace(StageStatusSearch))
            {

                list = list.Where(x => x.Stage.StatusLabel.Contains(applicationModel.StageStatusSearch, StringComparison.OrdinalIgnoreCase));

            }

            return list;
        }


        public IEnumerable<T> Sort<T>(IEnumerable<T> list) where T : Application
        {
            if ("name".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(x => x.FirstName);
                }
                else
                {
                    list = list.OrderByDescending(x => x.FirstName);
                }
            }

            if ("id".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(x => x.Id);
                }
                else
                {
                    list = list.OrderByDescending(x => x.Id);
                }
            }

            return list;
        }
    }
}
