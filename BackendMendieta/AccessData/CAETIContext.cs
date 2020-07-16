using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccessData
{
    public partial class CAETIContext : IdentityDbContext<SystemUser, SystemUserRole, string>
    {
        public CAETIContext()
        {
        }

        public CAETIContext(DbContextOptions<CAETIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SystemUser> SystemUser { get; set; }
        public virtual DbSet<SystemUserRole> SystemUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Database=ProyectoMendieta;Initial Catalog=CAETI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
