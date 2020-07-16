using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Microsoft.Extensions.Configuration;
using AccessData.Configurations;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AccessData
{
    public partial class AppDbContext: DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }// esta es la tabla Activity, con esta variable haremos las consultas
        public AppDbContext() 
        {
        }
        public  AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        public AppDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //  => options.UseSqlServer("Server=DESKTOP-SPT2LHA;Database=ProyectoMendieta;Trusted_Connection=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            //modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
         }

    }
}
// se suele tener una clase para cada entidad disstinra que resive un model builder asi 
// cada clase tiene su propio configuracion