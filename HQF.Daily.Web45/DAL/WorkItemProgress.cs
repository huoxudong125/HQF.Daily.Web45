namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItemProgress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "工程日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CurrentDate { get; set; }

        public int WorkItemId { get; set; }

        public int WorkTeamId { get; set; }

        public double WorkPrice { get; set; }

        public int WorkUnitId { get; set; }

        [Display(Name = "当日工作量")]
        public double WorkQuantity { get; set; }

        public int MixingStationId { get; set; }

        public int OperatorId { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [Display(Name = "新建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual ConcreteMixingStation ConcreteMixingStation { get; set; }

        public virtual User User { get; set; }

        public virtual WorkItem WorkItem { get; set; }

        public virtual WorkTeam WorkTeam { get; set; }

        public virtual WorkUnit WorkUnit { get; set; }
    }
}
