using EF01_Demo.Configration;
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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = SW-BYANMAGED ; Database = CompanyG02 ; Trusted_Connection = True ; Encrypt = False" );
            // we add  Encrypt = False => for cerificate ssl error.
            // OR : optionsBuilder.UseSqlServer("Server = . ; Database = CompanyG02 ; Trusted_Connection = True ");

            // To open connection you need to create an object from this class: 
            //in main programs : CompanyDBContext dBContext = new CompanyDBContext();

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDataAnnotation> EmployeeDataAnnotation { get; set; }
        // This is by convension
        public DbSet<Department> departments { get; set; }
        // department class should be public

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EmployeeDepartmentView> EmployeeDepartmentView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api:
            // To set Defult value
            modelBuilder.Entity<Employee>()
                         //.Property("EmpName")
                         // but we use the below overload for Property
                         .Property(E => E.EmpName)
                         .HasDefaultValue("Test")
                         .IsRequired(false); // to allow null



            // Using fluent Apis to create department table:
            //modelBuilder.Entity<Department>().ToTable("Departments");

            //To view : This is will not create a view in dataBase , this is to recive the data from view already.

            //modelBuilder.Entity<Department>().ToView("Departments");

            // modelBuilder.Entity<Department>().HasKey( D => D.DeptID );

            //modelBuilder.Entity<Department>().HasKey("DeptID");
            //modelBuilder.Entity<Department>().HasKey(nameof(Department.DeptID);

            //modelBuilder.Entity<Department>().Property( d => d.DeptID ).UseIdentityColumn(10,10);

            /* modelBuilder.Entity<Department>().Property(D => D.Name)
                                .HasColumnName("DeptName") // name of table in database
                                .HasColumnType("varchar")
                                .HasMaxLength(50)
                                .HasDefaultValue("TestDefaultValue")
                                .IsRequired(false);
            */
            //you can use dataAnnotation with Fluent Apis
            //.HasAnnotation("MaxLength" , "50");

            // To add default value to date column
            /* modelBuilder.Entity<Department>()
                        .Property(d => d.DateOfCreation)
                        //.HasDefaultValue(DateTime.Now) // it will return the time of migration not date of table cration
                        .HasDefaultValueSql("GETDATE()"); */

            // EF CORE 3.1 Feature : 

            //modelBuilder.Entity<Department>(E =>
            //{
            //    E.HasKey(D => D.DeptID);

            //    E.Property(d => d.DeptID).UseIdentityColumn(10, 10);

            //    E.Property(D => D.Name)
            //                    .HasColumnName("DeptName") // name of table in database
            //                    .HasColumnType("varchar")
            //                    .HasMaxLength(50)
            //                    .HasDefaultValue("TestDefaultValue")
            //                    .IsRequired(false);

            //    E.Property(d => d.DateOfCreation)
            //            //.HasDefaultValue(DateTime.Now) // it will return the time of migration not date of table cration
            //            .HasDefaultValueSql("GETDATE()");

            //});



            // OnModelCreating should apply the configartion in another class (we neeed to create an object of it as parametert to ApplyConfiguration method )
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigration());

            #region Relation using Fluent Api AND do some configration on it.

            modelBuilder.Entity<Department>()
                        .HasMany(d => d.Employess)
                        .WithOne(e => e.Department)
                        .OnDelete(DeleteBehavior.Cascade);

            /// Student Cousrs many to many realtion
            //modelBuilder.Entity<Student>()
            //            .HasMany(s => s.Courses)
            //            .WithMany(c => c.Students)
            //            ;
            // there is no represntaion for many to many relationship in dataBase

            #region CompositePrimary key for studentCourse

            modelBuilder.Entity<StudentCousre>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });

            //relationship one to many between student and studentCourse 
            //ملاحظة فصلت العلاقة بين الطالب والكورس
            modelBuilder.Entity<Student>()
                        .HasMany(s => s.StudentCourses)
                        .WithOne(sc => sc.Student)
                        .IsRequired(true)
                        .HasForeignKey(sc=>sc.StudentId);

            modelBuilder.Entity<Course>()
                        .HasMany(C => C.CourseStudents)
                        .WithOne(sc => sc.Course);

            #endregion


            #endregion



            // Defult value :

            modelBuilder.Entity<Department>()
                        .Property(D => D.DateOfCreation)
                        // .HasDefaultValue(DateTime.Now) => date of creation the table so now
                        .HasDefaultValueSql("GETDATE()"); // => DATE OF ADD DEPARTMENT TO THE TABLE


            modelBuilder.Entity<EmployeeDepartmentView>().ToView("EmployeeDepartmentView").HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
