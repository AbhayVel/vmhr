using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{
    [Table("application")]
    public class Application : IVacancy
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        public string Phone { get; set; }
        public string Gender { get; set; }
       
        public string Address { get; set; }
       
        public int? Experience { get; set; }
        public string Status { get; set; }
        
        public string Resume { get; set; }
        public int? VacancyId { get; set; }
        public int? StageId { get; set; }
        public DateTime DateCreated { get; set; }


        [ForeignKey("VacancyId")]
        public virtual Vacancy Vacancy { get; set; }


        [ForeignKey("StageId")]
        public virtual Stage Stage { get; set; }



    }
}
