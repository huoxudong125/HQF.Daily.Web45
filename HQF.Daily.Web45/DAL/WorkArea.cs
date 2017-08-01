namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkArea()
        {
            WorkItems = new HashSet<WorkItem>();
        }

        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public int ProjectId { get; set; }

        public string Remark { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItem> WorkItems { get; set; }
    }
}
