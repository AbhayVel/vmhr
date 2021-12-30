﻿using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{

    public class UserModel : BaseModel
    {

        public override string ColumnName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_columnName))
                {
                    return "UserId";
                }
                return _columnName;
            }

            set
            {

                _columnName = value;
            }
        }


        public string UserIdSearch { get; set; }
        public string NameSearch { get; set; }


        public IEnumerable<T> Where<T>(IEnumerable<T> list) where T : User
        {

            if (!string.IsNullOrWhiteSpace(UserIdSearch))
            {
                int value = 0;
                if (Int32.TryParse(UserIdSearch, out value))
                {
                    list = list.Where(x => x.UserId == value);
                }
            }
            if (!string.IsNullOrWhiteSpace(NameSearch))
            {

                list = list.Where(x => x.Name.Contains(NameSearch, StringComparison.OrdinalIgnoreCase));

            }

            return list;
        }

        public IEnumerable<T> Sort<T>(IEnumerable<T> list) where T: User   
            {
            if ("UserId".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(X => X.UserId);
                }
                else
                {
                    list = list.OrderByDescending(X => X.UserId);
                }
            }
            if ("Name".Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if (OrderBy.Equals("asc"))
                {
                    list = list.OrderBy(X => X.Name).ToList();
                }
                else
                {
                    list = list.OrderByDescending(X => X.Name).ToList();
                }
            }
            return list;
        }
    }
}
