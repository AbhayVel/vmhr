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
