namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItemPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int WorkItemId { get; set; }

        public int WorkTypeUnitId { get; set; }

        public int WorkTeamId { get; set; }

        [Display(Name = "价格")]
        public int Price { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual WorkItem WorkItem { get; set; }

        public virtual WorkTeam WorkTeam { get; set; }

        public virtual WorkTypeUnit WorkTypeUnit { get; set; }
    }
}
