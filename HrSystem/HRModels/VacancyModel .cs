using HREntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace HRModels
{
    public class VacancyModel : BaseModel
    {

        public override string OrderBy
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "asc";
                }
                return _orderBy;
            }

            set
            {
                _orderBy = value;
            }
        }
        public string IdSearch { get; set; }

        public string PositionSearch { get; set; }
      public string StatusSearch { get; set; }

      public IEnumerable<T> Where<T>(IEnumerable<T> list) where T: Vacancy
        {
            VacancyModel vacancyModel = this;
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(IdSearch, out value))
                {
                    list = list.Where(x => x.Id == value);
                }

            }

            if (!string.IsNullOrWhiteSpace(PositionSearch))
            {

                list = list.Where(x => x.Position.Contains(PositionSearch, StringComparison.OrdinalIgnoreCase));
            }
         if (!string.IsNullOrWhiteSpace(StatusSearch))
         {

            list = list.Where(x => x.Status.Contains(StatusSearch, StringComparison.OrdinalIgnoreCase));
         }
         return list;
        }
        
        public IEnumerable<T> Sort<T>(IEnumerable<T> list) where T : Vacancy
        {
            if ("position".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(x => x.Position);
                }

                else
                {
                    list = list.OrderByDescending(x => x.Position);
                }
            }
            list = list.ToList();

            if ("id".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                   list = list.OrderBy(x => x.Id).ToList();
                }

                else
                {
                    list = list .OrderByDescending(x => x.Id).ToList();
                }
            }

         if ("status".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
         {
            if (OrderBy.Equals("asc"))
            {
               list = list.OrderBy(x => x.Status);
            }

            else
            {
               list = list.OrderByDescending(x => x.Status);
            }
         }
         list = list.ToList();
         return list;
        }
    }
}
