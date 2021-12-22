using System;

namespace HREntity
{
    public class Vacancy
    {
        public int Id { get; set; }


        public string Position { get; set; }

        public string Skills { get; set; }

        public string Experience { get; set; }

        public int Availability { get; set; }

        public string Status { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
