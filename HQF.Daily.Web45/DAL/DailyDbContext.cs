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
        }

        public virtual DbSet<Companys> Companys { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<WorkAreas> WorkAreas { get; set; }
        public virtual DbSet<WorkItemPrices> WorkItemPrices { get; set; }
        public virtual DbSet<WorkItemProgresses> WorkItemProgresses { get; set; }
        public virtual DbSet<WorkItems> WorkItems { get; set; }
        public virtual DbSet<WorkTeams> WorkTeams { get; set; }
        public virtual DbSet<WorkTypes> WorkTypes { get; set; }
        public virtual DbSet<WorkTypeUnits> WorkTypeUnits { get; set; }
        public virtual DbSet<WorkUnits> WorkUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>()
                .HasMany(e => e.WorkAreas)
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<WorkAreas>()
                .HasMany(e => e.WorkItems)
                .WithRequired(e => e.WorkAreas)
                .HasForeignKey(e => e.WorkAreaId);

            modelBuilder.Entity<WorkItemPrices>()
                .HasMany(e => e.WorkItemProgresses)
                .WithOptional(e => e.WorkItemPrices)
                .HasForeignKey(e => e.WorkItemPriceId);

            modelBuilder.Entity<WorkItems>()
                .HasMany(e => e.WorkItemProgresses)
                .WithRequired(e => e.WorkItems)
                .HasForeignKey(e => e.WorkItemId);

            modelBuilder.Entity<WorkItems>()
                .HasMany(e => e.WorkItems1)
                .WithOptional(e => e.WorkItems2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<WorkTeams>()
                .HasMany(e => e.WorkItemPrices)
                .WithRequired(e => e.WorkTeams)
                .HasForeignKey(e => e.WorkTeamId);

            modelBuilder.Entity<WorkTeams>()
                .HasMany(e => e.WorkItemProgresses)
                .WithRequired(e => e.WorkTeams)
                .HasForeignKey(e => e.WorkTeamId);

            modelBuilder.Entity<WorkTeams>()
                .HasMany(e => e.WorkItems)
                .WithOptional(e => e.WorkTeams)
                .HasForeignKey(e => e.WorkTeamId);

            modelBuilder.Entity<WorkTypes>()
                .HasMany(e => e.WorkItems)
                .WithRequired(e => e.WorkTypes)
                .HasForeignKey(e => e.WorkTypeId);

            modelBuilder.Entity<WorkTypes>()
                .HasMany(e => e.WorkTypes1)
                .WithOptional(e => e.WorkTypes2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<WorkTypes>()
                .HasMany(e => e.WorkTypeUnits)
                .WithRequired(e => e.WorkTypes)
                .HasForeignKey(e => e.WorkTypeId);

            modelBuilder.Entity<WorkTypeUnits>()
                .HasMany(e => e.WorkItemPrices)
                .WithRequired(e => e.WorkTypeUnits)
                .HasForeignKey(e => e.WorkTypeUnitId);

            modelBuilder.Entity<WorkUnits>()
                .HasMany(e => e.WorkTypeUnits)
                .WithRequired(e => e.WorkUnits)
                .HasForeignKey(e => e.WorkUnitId);
        }
    }
}
