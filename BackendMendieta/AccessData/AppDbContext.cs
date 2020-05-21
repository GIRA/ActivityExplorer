using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Microsoft.Extensions.Configuration;
using AccessData.Configurations;
using System.Reflection;

namespace AccessData
{
    public class AppDbContext:DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlServer("Server=DESKTOP-SPT2LHA;Database=ProyectoMendieta;Trusted_Connection=True;");


         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            //modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         }

    }
}
// se suele tener una clase para cada entidad disstinra que resive un model builder asi 
// cada clase tiene su propio configuracion