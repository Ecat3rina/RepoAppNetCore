using Microsoft.EntityFrameworkCore;
using RepoApp.DAL.Entities;

namespace RepoApp.DAL.Context
{
    public class FirstContext : DbContext
    {
        public FirstContext(DbContextOptions<FirstContext> options)
              : base(options)
        {
        }

        public DbSet<DMDepartment> Departments { get; set; }
        public DbSet<DMProject> Projects { get; set; }
        public DbSet<DMRepository> Repositories { get; set; }
        public DbSet<DMRepositoryType> RepositoryTypes { get; set; }
        public DbSet<DMRole> Roles { get; set; }
        public DbSet<DMUser> Users { get; set; }
        public DbSet<DMUserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Department
            modelBuilder.Entity<DMDepartment>()
                
                .HasMany(x => x.Projects)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Department

            #region Project
            modelBuilder.Entity<DMProject>()
                .HasMany(x => x.Repositories)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Project

            #region RepositoryType
            modelBuilder.Entity<DMRepositoryType>()
                .HasMany(x => x.Repositories)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion RepositoryType

            #region Repository

            #endregion Repository

            #region Role
            modelBuilder.Entity<DMRole>()
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Role

            #region User
            modelBuilder.Entity<DMUser>()
                .HasMany(x => x.Repositories)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DMUser>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DMUser>()
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion User


            modelBuilder.Entity<DMUserRole>()
                .HasKey(x=> new { x.UserId, x.RoleId});
            modelBuilder.Entity<DMUserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x=>x.RoleId);
            modelBuilder.Entity<DMUserRole>()
               .HasOne(x => x.User)
               .WithMany(x => x.UserRoles)
               .HasForeignKey(x => x.UserId);

          

            modelBuilder.Entity<DMUser>().HasData(SeedConfiguration.user1);
            modelBuilder.Entity<DMRole>().HasData(SeedConfiguration.AdminRole);
            modelBuilder.Entity<DMUserRole>().HasData(SeedConfiguration.userRole);
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
