using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREntity
{

    public interface IStage
    {
        [Display(Name ="Stage")]
        public int? StageId { get; set; }
        public Stage Stage { get; set; }
    }


    [Table("Stage")]
    public class Stage
    {   [Key]
        public int Id { get; set; }

        public string? Status { get; set; }


        public string StatusLabel { get; set; }

       

       
    }
}
