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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "全名")]
        public string FullName { get; set; }

        [Display(Name = "合同")]
        public string ContractName { get; set; }

        [Display(Name = "手机号")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "工程队名")]
        public string Name { get; set; }

        [Display(Name = "电话号码")]
        public string TelPhone { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "新建时间")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "更新时间")]
        public DateTime UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemPrice> WorkItemPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkItemProgress> WorkItemProgresses { get; set; }
    }
}
