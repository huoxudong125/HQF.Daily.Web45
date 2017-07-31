namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkItems()
        {
            WorkItemProgresses = new HashSet<WorkItemProgresses>();
            WorkItems1 = new HashSet<WorkItems>();
        }

        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public string Remark { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        public int WorkAreaId { get; set; }

        public int? WorkTeamId { get; set; }

        public int WorkTypeId { get; set; }

        public virtual WorkAreas WorkAreas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemProgresses> WorkItemProgresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItems> WorkItems1 { get; set; }

        public virtual WorkItems WorkItems2 { get; set; }

        public virtual WorkTeams WorkTeams { get; set; }

        public virtual WorkTypes WorkTypes { get; set; }
    }
}
