using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{

    public interface IStage
    {
        public int? StageId { get; set; }
        public Stage Stage { get; set; }
    }


    [Table("Stage")]
    public class Stage
    {   [Key]
        public int Id { get; set; }

        public int? StageID { get; set; }

        
        public string StatusLabel { get; set; }

       

       
    }
}
