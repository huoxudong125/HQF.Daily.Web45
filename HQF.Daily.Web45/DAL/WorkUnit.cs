namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkUnit()
        {
            WorkTypeUnits = new HashSet<WorkTypeUnit>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "µ¥Î»Ãû³Æ")]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual WorkItemProgress WorkItemProgress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkTypeUnit> WorkTypeUnits { get; set; }
    }
}
