namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkTeam()
        {
            WorkItemPrices = new HashSet<WorkItemPrice>();
            WorkItemProgresses = new HashSet<WorkItemProgress>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string ContractName { get; set; }

        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "工程队名")]
        public string Name { get; set; }

        public string TelPhone { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemPrice> WorkItemPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemProgress> WorkItemProgresses { get; set; }
    }
}
