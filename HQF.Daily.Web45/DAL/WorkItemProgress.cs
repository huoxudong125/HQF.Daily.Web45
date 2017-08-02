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

        [Display(Name="新建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "工程日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime CurrentDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public int? WorkItemPriceId { get; set; }

        [Display(Name ="当日工作量")]
        public double WorkQuantity { get; set; }

        [Display(Name ="单价")]
        public virtual WorkItemPrice WorkItemPrice { get; set; }
    }
}
