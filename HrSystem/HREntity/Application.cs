using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{
    [Table("application")]
    public class Application
    {
        [Key]

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public string Email { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
       
        public string Address { get; set; }
        public string AppliedFor { get; set; }
        public int? Experience { get; set; }
        public string Status { get; set; }
        
        public string Resume { get; set; }
        public int? ProcessId { get; set; }
        public int? PositionId { get; set; }
        public DateTime DateCreated { get; set; }



    }
}
