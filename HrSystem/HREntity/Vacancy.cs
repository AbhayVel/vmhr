﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{
    [Table("vacancy")]
    public class Vacancy
    {   [Key]
        public int Id { get; set; }


        public string Position { get; set; }

        public string Skills { get; set; }


        public int? Availability { get; set; }

        public string Description { get; set; }
       
        public decimal? Experience { get; set; }

      

        public string Status { get; set; }
        [Column ("date_created")]

        public DateTime DateCreated { get; set; }
    }
}
