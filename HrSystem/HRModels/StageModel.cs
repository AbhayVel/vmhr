using HREntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace HRModels
{
    public class StageModel : BaseModel
    {

       public string IdSearch { get; set; }

      public IEnumerable<T> Where<T>(IEnumerable<T> list) where T: Stage
        {
            StageModel stageModel = this;
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(IdSearch, out value))
                {
                    list = list.Where(x => x.Id == value);
                }

            }

            

            return list;
        }
        
        public IEnumerable<T> Sort<T>(IEnumerable<T> list) where T : Stage
        {
            if ("StatusLabel".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(x => x.StatusLabel);
                }

                else
                {
                    list = list.OrderByDescending(x => x.StatusLabel);
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
            return list;
        }
    }
}
