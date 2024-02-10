using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Clinique> Cliniques { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=CliniqueDB;Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
           
            //Q4.a
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.IsNullable = false;
            }

            //Q4.b
            modelBuilder.Entity<Chambre>().HasOne(c => c.Clinique).WithMany(cl => cl.Chambres).HasForeignKey(c => c.CliniqueFK);
            modelBuilder.Entity<Admission>().HasKey(a => new { a.DateAdmission, a.PatientFK, a.ChambreFK });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //configurationBuilder
            //    .Properties<string>()
            //    .HaveMaxLength(50);


            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);


            //configurationBuilder
            //  .Properties<DateTime>()
            //      .HaveColumnType("date");
        }

    }
}
