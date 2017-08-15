namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConcreteMixingStation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConcreteMixingStation()
        {
            WorkItemProgresses = new HashSet<WorkItemProgress>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemProgress> WorkItemProgresses { get; set; }
    }
}
