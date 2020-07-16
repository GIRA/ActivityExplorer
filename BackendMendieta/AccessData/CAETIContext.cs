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
        public CAETIContext(string connectionString) : base(GetOptions(connectionString))
        {

        }

        public virtual DbSet<SystemUser> SystemUser { get; set; }
        public virtual DbSet<SystemUserRole> SystemUserRoles { get; set; }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
