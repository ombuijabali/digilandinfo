using Geoportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Geoportal.DbContext
{
    public class GeoportalDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public GeoportalDbContext(DbContextOptions<GeoportalDbContext> options) : base(options)
        {
        }

        public DbSet<ParcelModel> Parcels { get; set; }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<ValidationModel> Validations { get; set; }
        public DbSet<SurveyModel> Survey { get; set; }
        public DbSet<RevenueModel> Revenue { get; set; }
        public DbSet<WaterUser> WaterUsers { get; set; }
        public DbSet<LandModel> Land { get; set; }
        public DbSet<PermitsModel> Permits { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DocumentsModel> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParcelModel>().ToTable("parcels").HasKey(p => p.ID_Number);
            modelBuilder.Entity<SurveyModel>().ToTable("survey").HasKey(s => s.ID);
            modelBuilder.Entity<RevenueModel>().ToTable("revenues").HasKey(s => s.Id);

            modelBuilder.Entity<UsersModel>().ToTable("clients"); // Update the table name
            modelBuilder.Entity<UsersModel>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<LoginModel>().ToTable("users"); // Update the table name
            modelBuilder.Entity<LoginModel>()
                .HasOne(l => l.Role)
                .WithMany()
                .HasForeignKey(l => l.RoleId);

            // Configure table and primary key for DocumentsModel
            modelBuilder.Entity<DocumentsModel>().ToTable("documents").HasKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
