namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItemProgresses
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CurrentDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public int WorkItemId { get; set; }

        public int? WorkItemPriceId { get; set; }

        public long WorkQuantity { get; set; }

        public int WorkTeamId { get; set; }

        public virtual WorkItemPrices WorkItemPrices { get; set; }

        public virtual WorkItems WorkItems { get; set; }

        public virtual WorkTeams WorkTeams { get; set; }
    }
}
