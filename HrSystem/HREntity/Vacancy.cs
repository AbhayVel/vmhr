using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{

  public  interface IVacancy
    {
        public int? VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
    [Table("vacancy")]
    public class Vacancy
    {   [Key]
        public int? Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Position { get; set; }

        [Required]
        public string Skills { get; set; }


        public int Availability { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal? Experience { get; set; }

      

        public string Status { get; set; }
        [Column ("date_created")]

        public DateTime DateCreated { get; set; }
    }
}
