using Microsoft.EntityFrameworkCore;
using PartTwoInhertince_Session2EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTwoInhertince_Session2EF.Contexts
{
    internal class Company02DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = Company02 ; Trusted_Connection = true ;  Encrypt = False");
        }


        //public DbSet<FullTimeEmployee>   FullTimeEmployee { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployee { get; set; }
        /// <summary>
        ///  => I use shema TPH So i want to be one table with one dbset named Employe
        /// </summary>
         public DbSet<Employee> Employees { get; set; }
        /// <param name="modelBuilder"></param>

        #region TPH Table per hirearchy by fluent Apis

        //كلهم في جدول واحد
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FullTimeEmployee>()
                        .HasBaseType<Employee>();

            modelBuilder.Entity<PartTimeEmployee>()
                         .HasBaseType<Employee>();

            // TPH => Map fullTime & partTime Employee to One Table.
            // Add => new coulmn Nvarchar Named Disciminator [FullTime | partTime].
            // There is two dbset  DbSet<FullTimeEmployee> ,  DbSet<PartTimeEmployee> to one Table => Employee

            base.OnModelCreating(modelBuilder);
        } 
        #endregion

    }
}
