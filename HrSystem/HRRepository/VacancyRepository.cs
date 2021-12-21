
using System;
using HREntity;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HRModels;

namespace HRRepository
{
   public  class VacancyRepository
    {
        public int TotalRowCount { get; private set; }

        public List<Vacancy>  GetAll(VacancyModel vacancyModel, PageModel pageModel)
        {
            string columnName = vacancyModel.columnName;
            string orderBy = vacancyModel.orderBy;

            List<Vacancy> lstVacancy = new List<Vacancy>();
            lstVacancy.Add(new Vacancy
            {
                Id = 1,
                Position = "DotNet Developer",
                Skills = "C#",
                Experience = "2 year",
                Availability = 5,
                Status = "Active"
            });

            lstVacancy.Add(new Vacancy
            {
                Id = 2,
                Position = "Software Developer",
                Skills = "Java",
                Experience = "3 year",
                Availability = 5,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 3,
                Position = "Web Developer",
                Skills = "HTML",
                Experience = "2 year",
                Availability = 7,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 4,
                Position = "DotNet Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 5,
                Position = "DotNet Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 6,
                Position = "Java Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 7,
                Position = "UI Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });

            lstVacancy.Add(new Vacancy
            {
                Id = 8,
                Position = "UI Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });

            lstVacancy.Add(new Vacancy
            {
                Id = 9,
                Position = "UI Developer2",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 10,
                Position = "DotNet Developer",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });

            lstVacancy.Add(new Vacancy
            {
                Id = 11,
                Position = "DotNet Developer",
                Skills = "C#",
                Experience = "2 year",
                Availability = 2,
                Status = "Active"
            });
            lstVacancy.Add(new Vacancy
            {
                Id = 12,
                Position = "DotNet Developer4",
                Skills = "C#",
                Experience = "4 year",
                Availability = 2,
                Status = "Active"
            });
            IEnumerable<Vacancy> vacancyIEnum = lstVacancy;
            if (!string.IsNullOrWhiteSpace(vacancyModel.IdSearch))
            {
                int value = 0;
                if (Int32.TryParse(vacancyModel.IdSearch, out value))
                {
                    vacancyIEnum = vacancyIEnum.Where(x => x.Id==value);
                }

            }

            if (!string.IsNullOrWhiteSpace(vacancyModel.PositionSearch))
            {
               
                    vacancyIEnum = vacancyIEnum.Where(x => x.Position.Contains(vacancyModel.PositionSearch,StringComparison.OrdinalIgnoreCase));
             }
            if ("position".Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                if (orderBy.Equals("asc"))
                {
                    lstVacancy = lstVacancy.OrderBy(x => x.Position).ToList();
                }

                else
                {
                    lstVacancy = lstVacancy.OrderByDescending(x => x.Position).ToList();
                }
            }
            lstVacancy = vacancyIEnum.ToList();
            
            if ("id".Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                if (orderBy.Equals("asc"))
                {
                    lstVacancy = lstVacancy.OrderBy(x => x.Id).ToList();
                }

                else
                {
                    lstVacancy = lstVacancy.OrderByDescending(x => x.Id).ToList();
                }
            }

            if (!(pageModel is null))
            {
                pageModel.TotalRowCount = lstVacancy.Count;
                int pageCount = (int)Math.Ceiling(pageModel.TotalRowCount*1.0 / pageModel.RowPerPage * 1.0);
                if (pageModel.CurrentPage > pageCount)
                {
                    pageModel.CurrentPage = 1;
                }
                int startIndex = (pageModel.CurrentPage - 1) * pageModel.RowPerPage;
                if (startIndex > pageModel.TotalRowCount - 1)
                {
                    startIndex = 0;
                }
                //if (startIndex > pageModel.TotalRowCount - 1)
                //{
                //   startIndex = 0;
                //}
                int endIndex = startIndex + pageModel.RowPerPage-1;

                if(endIndex>pageModel.TotalRowCount-1)
                {
                    endIndex = pageModel.RowPerPage - 1;
                }
                pageModel.StartIndex = startIndex;
                pageModel.PageCount = pageCount;
                pageModel.EndIndex = endIndex;

                lstVacancy = lstVacancy.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();



            }
            return lstVacancy;
        }
         

    }
}
