namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItemProgress
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CurrentDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public int? WorkItemPriceId { get; set; }

        public double WorkQuantity { get; set; }

        public virtual WorkItemPrice WorkItemPrice { get; set; }
    }
}
