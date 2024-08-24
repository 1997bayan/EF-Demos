using EF01_Demo.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EF01_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.First call the connections by creating an object from context class
            CompanyDBContext dBContext = new CompanyDBContext();
            //2. use the object with table property 
            dBContext.Employees.Where(E => E.Id  == 1);


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
        }
        ///To remove the initaCreate :
        ///Use Update-DateBase 0
        ///
        #region Data Annotation (set of attributes used for Data Validation

        #endregion
    }
}
