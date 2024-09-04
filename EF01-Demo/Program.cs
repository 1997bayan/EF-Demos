using EF01_Demo.Contexts;
using EF01_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EF01_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.First call the connections by creating an object from context class
           // CompanyDBContext dBContext = new CompanyDBContext();
            //2. use the object with table property 
           // dBContext.Employees.Where(E => E.Id  == 1);


            //Old way for mapping the dataBase
            //dBContext.Database.EnsureDeleted();
            //dBContext.Database.EnsureCreated();

            /// so we use Migration : migtated = مطابق له
            /// to apply any change happen in dataBase:
            /// First install : Microsoft.EntityFrameWorkCore.tools
            /// then use package Manager Console
            /// PM> Add-Migration initialCreate => initialCreate is the name of migration
            /// Apply (ya3ni execute up method) Migration :There are Two ways:
            /// 1- dBContext.Database.Migrate();
            /// 2- Through Package manager console => Update-Database
            /// But before the migration i need to track what happen in SQL we use SQL server Profiler
            // dBContext.Database.Migrate();


            //when you remove migration it will remove the last one you created ( beacuse it is store 
            /// in stack .(Fist in , Last out).
            /// to remove migration you need to revert it first [Roll back]
            /// there are two solutions to do Roll back : 1-Apply the pervious migration or apply the current migration down method
            /// Apply the pervious migration=> PM> Update-Database -Migration "initialCreate"
            /// // then : Pm: => Remove Migration
            ///To remove the initaCreate :
            ///Use Update-DateBase 0
            ///
            #region Data Annotation (set of attributes used for Data Validation

            #endregion

            #region Fluent API
            /// When we use Fluent API?
            /// 1-Composite primary key
            /// 2- Set Default value for column
            /// 3- if i dont have source code for the entity [ex : class for string i have the IEL]
            /// USES : (IN DBCONTEXT CLASS => use : OnModelCreating()

            //dbContext.Department => inValid
            //dBContext.Set<Department>().Add()

            #endregion

            #region CRUD operations
            // 1- open connection with database
            // 2- after fininsh the work you should close the connection

            try
            {
                // CRUD ==> Query object Model
            }
            finally 
            {
                
                //Release || Free || Deallocate || close || dispose unManaged Resoirces
                //dBContext.Dispose(); // Close db connection

            }

            // Or use syntax suger => try finally
            // using block : how Dispose work in using block ??
            // using (CompanyDBContext dBContext = new CompanyDBContext())
            //  {

            //  }
            //syntax suger , how Dispose work in using ?? it will Dispose automatically ?
            using CompanyDBContext dBContext = new CompanyDBContext();

            // CRUD => Query object model

            EmployeeDataAnnotation Emp01 = new EmployeeDataAnnotation()
            {
                //EmpId = 1, // INVALID => COULMN HAS IDENTITY
                Name = "Bayan",
                Age = 28,
                Salary = 60000,
                Email = "Bayan@gmail.com",
                Password ="password",
                PhoneNumber = "1234567890",
            };

            EmployeeDataAnnotation Emp02 = new EmployeeDataAnnotation()
            {
               
                Name = "Omar",
                Age = 30,
                Salary = 604000,
                Email = "Omar@gmail.com",
                Password = "password",
                PhoneNumber = "1234567890",
            };
            //what is the state of these employee based on the dataBase?
            #region Add / Insert 
            //Console.WriteLine(dBContext.Entry(Emp01).State); // Detached
            //Console.WriteLine(dBContext.Entry(Emp02).State); // Detached

            //// How EF know that Emp01 is Detached?? using tracker

            //dBContext.EmployeeDataAnnotation.Add(Emp01); // Add locally
            //dBContext.EmployeeDataAnnotation.Add(Emp02); // Add locally

            //// There are 4 ways to add Emp01:
            /////  dBContext.Set<EmployeeDataAnnotation>().Add(Emp01);
            ///// dBContext.Add(Emp01); // EF core  3.1
            ////4 - change the object state
            ///// dBContext.Entry(Emp01).State = EntityState.Added;

            //Console.WriteLine(dBContext.Entry(Emp01).State); // Added locally , not in DataBase
            //Console.WriteLine(dBContext.Entry(Emp02).State); // Added locally , not in DataBase


            //// Add remotly in DataBase
            //dBContext.SaveChanges(); // Add remotly 

            //Console.WriteLine(dBContext.Entry(Emp01).State); // Unchanged
            //Console.WriteLine(dBContext.Entry(Emp02).State); // Unchanged
            //Console.WriteLine("=============");
            //Console.WriteLine("Emp01: " + Emp01.EmpId);
            //Console.WriteLine("Emp02: " + Emp02.EmpId);



            #endregion

            #region Retrive [Read]

            var  Employee = (from E in dBContext.EmployeeDataAnnotation
                             where E.EmpId == 1
                            select E).FirstOrDefault();
            //Console.WriteLine(Employee?.Name?? "Not Found");
            //Console.WriteLine(Employee.EmpId);


            #endregion

            #region Update
            //Emp01.Name = "Hamada";
            //Console.WriteLine(dBContext.Entry(Emp01).State); //Detached
            //Console.WriteLine(dBContext.Entry(Employee).State); 
            //Employee.Name = "dh";
            //Console.WriteLine(dBContext.Entry(Employee).State);

            ////dBContext.SaveChanges();
            //Console.WriteLine("=========");
            //Console.WriteLine(dBContext.Entry(Employee).State);

            #endregion
            /* Console.WriteLine("=========");
             Console.WriteLine(dBContext.Entry(Employee).State);
             dBContext.Remove(Employee);
             Console.WriteLine(dBContext.Entry(Employee).State);
             dBContext.SaveChanges();
             Console.WriteLine(dBContext.Entry(Employee).State); */






            #endregion

            #region One To many Relation between Employee and department 
            #endregion
            #region Many to many between Student and Course
            #endregion

            #region Inheritance Mapping 

            #endregion

            #region Retrive data

            // 1- open the connection with dataBase

            #region Without Loading
            //var Employee01 = (from E in dBContext.EmployeeDataAnnotation
            //                  where E.EmpId == 5
            //                  select E).FirstOrDefault();

            //Console.WriteLine($"Emp Name : {Employee01?.Name ?? "Not Found"} , DEPTNAME : {Employee01?.Department?.Name ?? "NO department"}");

            //var Department = (from D in dBContext.departments
            //                  where D.DeptID == 40
            //                  select D).FirstOrDefault();

            //Console.WriteLine($"Department (40) == {Department?.Name ?? "Not Found"}");


            #endregion
            #region Explicit loading
            var Employee01 = (from E in dBContext.EmployeeDataAnnotation
                              where E.EmpId == 6
                              select E).FirstOrDefault();

            dBContext.Entry(Employee01).Reference(E => E.Department ).Load();

            Console.WriteLine($"Emp Name : {Employee01?.Name ?? "Not Found"} , DEPTNAME : {Employee01?.Department?.Name ?? "NO department"}");

            var Department = (from D in dBContext.departments
                              where D.DeptID == 40
                              select D).FirstOrDefault();
            Console.WriteLine("====================");
            Console.WriteLine($"Department (40) == {Department?.Name ?? "Not Found"}");
            dBContext.Entry(Department).Collection(d => d.Employess).Load();
            Console.WriteLine("====================");

            foreach (var E in Department.Employess)
            {
                Console.WriteLine(E.Name );
            }



            #endregion

            #region Eager loading
            Console.WriteLine("Eager loading =========");
            //Eager loading will load the data even if not calling.

            var Employee02 = (from E in dBContext.EmployeeDataAnnotation.Include(E =>E.Department)
                              where E.EmpId == 7
                              select E).FirstOrDefault();

            var Department02 = (from D in dBContext.departments.Include(d =>d.Employess)
                              where D.DeptID == 50
                              select D).FirstOrDefault();
            Console.WriteLine($"Emp Name : {Employee02?.Name ?? "Not Found"} , DEPTNAME : {Employee02?.Department?.Name ?? "NO department"}");

            
            Console.WriteLine($"Department (50) == {Department02?.Name ?? "Not Found"}");
            
            Console.WriteLine("====================");

            foreach (var E in Department02.Employess)
            {
                Console.WriteLine(E.Name);
            }

            #endregion

            #region Lazy loading
            // 1- install package for Lazy loading => entityframeworkcore.proxies
            // // enable lazyloading enviroment  
            //2- in dbcontext add uselazyloadingProxies()
            // 3- add virtual to all navigation properties in the project
            // 4- make all entity to be public
            // send two request to get the data when i need it.

            Console.WriteLine("Lazy loading ");
            var Employee03 = (from E in dBContext.EmployeeDataAnnotation
                              where E.EmpId == 8
                              select E).FirstOrDefault();

            Console.WriteLine($"Emp Name : {Employee03?.Name ?? "Not Found"} , DEPTNAME : {Employee03?.Department?.Name ?? "NO department"}");
            #endregion

            #endregion

        }
    }
}
