using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Login.Data
{
    public partial class CAETIContext : DbContext
    {
        public CAETIContext()
        {
        }

        public CAETIContext(DbContextOptions<CAETIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Database=CAETI;Initial Catalog=CAETI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginEmail);

                entity.Property(e => e.LoginEmail)
                    .HasColumnName("Login_Email")
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .IsRequired()
                    .HasColumnName("Login_Password")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LoginUserId).HasColumnName("Login_UserId");

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.LoginUserId)
                    .HasConstraintName("FK_Login_User");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.Property(e => e.SystemUserId)
                    .HasColumnName("SystemUser_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SystemUserCity)
                    .IsRequired()
                    .HasColumnName("SystemUser_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserDni)
                    .HasColumnName("SystemUser_Dni")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserEmail)
                    .IsRequired()
                    .HasColumnName("SystemUser_Email")
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserImage)
                    .HasColumnName("SystemUser_Image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserInstitution)
                    .HasColumnName("SystemUser_Institution")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserLastName)
                    .IsRequired()
                    .HasColumnName("SystemUser_LastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserName)
                    .IsRequired()
                    .HasColumnName("SystemUser_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserPassword)
                    .IsRequired()
                    .HasColumnName("SystemUser_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserPhone)
                    .IsRequired()
                    .HasColumnName("SystemUser_Phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
