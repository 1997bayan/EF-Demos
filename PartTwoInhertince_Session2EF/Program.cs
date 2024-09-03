using PartTwoInhertince_Session2EF.Contexts;
using PartTwoInhertince_Session2EF.Entities;

namespace PartTwoInhertince_Session2EF
{
    internal class Program
    {
        static void Main()
        {
            // 1- connect with DataBase :
            using Company02DbContext dbContext = new Company02DbContext();

          FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
          {
              Name = " Aya",
              Address="Street-city",
              Age = 25 ,
              Salary = 20_0000,
              StartDate =DateTime.Now,
          };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "Amr",
                Address = "Street-city",
                Age = 30 ,
                CountOfHours = 20,
                HourRate = 100
            };

            // 2-Added LOCALLY 
           // dbContext.FullTimeEmployee.Add(fullTimeEmployee);
           // dbContext.PartTimeEmployee.Add(partTimeEmployee);
            // 3- Save Changes Add remotly
            dbContext.SaveChanges();

            //4 - retrive from dataBse

          // var FTEmplloyee = from FTE in dbContext.FullTimeEmployee
                     // select FTE;
           // var partTimeEmployeesInDataBase = from PTE in dbContext.PartTimeEmployee
                                            //  select PTE;
           // foreach( var FTE in FTEmplloyee )
               // Console.WriteLine( "Full Time Employee :" +FTE.Name + " ");

            Console.WriteLine("=====================");
            //foreach (var PTE in partTimeEmployeesInDataBase)
            // Console.WriteLine("Part Time Employee :" + PTE.Name + " ");
            /// WE i created only dbset <Employee>
            /// So i need to specify which Employee i need to retrive
            var Employees = from E in dbContext.Employees
                            select E;

            foreach (var employee in Employees.OfType<FullTimeEmployee>())
            {
                Console.WriteLine($"{employee.Name} , {employee.Salary}");
            }





            #region DataSetup


            #endregion
        }
    }
}
