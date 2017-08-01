namespace HQF.Daily.Web45.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DailyDbContext : DbContext
    {
        public DailyDbContext()
            : base("name=DailyDbContext")
        {
            Database.SetInitializer<DailyDbContext>(new DailyDbContextInitializer());

        }

        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<WorkArea> WorkAreas { get; set; }
        public virtual DbSet<WorkItemPrice> WorkItemPrices { get; set; }
        public virtual DbSet<WorkItemProgress> WorkItemProgresses { get; set; }
        public virtual DbSet<WorkItem> WorkItems { get; set; }
        public virtual DbSet<WorkTeam> WorkTeams { get; set; }
        public virtual DbSet<WorkType> WorkTypes { get; set; }
        public virtual DbSet<WorkTypeUnit> WorkTypeUnits { get; set; }
        public virtual DbSet<WorkUnit> WorkUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkItem>()
                .HasMany(e => e.WorkItemPrices)
                .WithRequired(e => e.WorkItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkItem>()
                .HasMany(e => e.SubWorkItems)
                .WithOptional(e => e.ParentWorkItem)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<WorkType>()
                .HasMany(e => e.SubWorkTypes)
                .WithOptional(e => e.ParentWorkType)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
