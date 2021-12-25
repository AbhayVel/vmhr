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

        public string FullName { get; set; }
        public string AppliedFor { get; set; }

        public string Status { get; set; }
        public int? Experience { get; set; }
        public string Resume { get; set; }
        public int? ProcessId { get; set; }
        public int? PositionId { get; set; }
        public DateTime DateCreated { get; set; }



    }
}
