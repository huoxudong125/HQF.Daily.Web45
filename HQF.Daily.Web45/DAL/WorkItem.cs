namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkItem()
        {
            WorkItemPrices = new HashSet<WorkItemPrice>();
            WorkItemProgresses = new HashSet<WorkItemProgress>();
            SubWorkItems = new HashSet<WorkItem>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "工程名")]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        public int WorkAreaId { get; set; }

        public int WorkTypeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual WorkArea WorkArea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemPrice> WorkItemPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemProgress> WorkItemProgresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItem> SubWorkItems { get; set; }

        public virtual WorkItem ParentWorkItem { get; set; }

        public virtual WorkType WorkType { get; set; }
    }
}
