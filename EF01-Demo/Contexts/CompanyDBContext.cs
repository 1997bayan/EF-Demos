using EF01_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Contexts
{  /// <summary>
/// This is the class which is responsable for connection class 
/// 
/// DbContext this calss contains : on configuraing method that that stringConnection
/// First Install the compataible package through package Manger console :
/// PM> Install-Package "Microsoft.EntityFrameWorkCore.sqlServer"
/// </summary>
    internal class CompanyDBContext :DbContext

    {
        public CompanyDBContext() :base() // By Default : there is chaning between parent constrouctor and its child // Dynamic binding
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //OLD NAME : optionsBuilder.UseSqlServer("Data Source = SW-BYANMAGED ; Initial Catalog  = CompanyG02 ;  Integrated Security = True ");
            optionsBuilder.UseSqlServer("Server = SW-BYANMAGED ; Database = CompanyG02 ; Trusted_Connection = True ; Encrypt = False");
            // we add  Encrypt = False => for cerificate ssl error.
            // OR : optionsBuilder.UseSqlServer("Server = . ; Database = CompanyG02 ; Trusted_Connection = True ");

            // To open connection you need to create an object from this class: 
            //in main programs : CompanyDBContext dBContext = new CompanyDBContext();

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDataAnnotation> EmployeeDataAnnotation { get; set; }



    }
}
