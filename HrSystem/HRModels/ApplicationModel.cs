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

                list = list.Where(x => x.Name.Contains(applicationModel.NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            return list;
        }

    }
}
