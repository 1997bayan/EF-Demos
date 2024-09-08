using DataBaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // First install backages :
            // => Microsoft.EntityFrameCore.SqlServer
            // => Microsoft.EntityFrameCore.tools

            // Second :
            // Write the command 
            // PM > Scaffold-DbContext " Server = . , Database = Northwind , Trusted_Connection = true " Microsoft.EntityFrameCore.SqlServer 
            // - schemas dbo -tables Products , Suppliers , Categories ,"Products Above Average Price " لان الاسم فيه سبيس حطيت ال"" -context DatabaseFirstDbContext -ContextDir Contexts
            // -OutPutDir Models -DataAnnotation

            #region Database First Approch [Wizard]
            //extension per visual studio ⇒ EF power tool
            //close visual studio 
           using NorthwindDBContext dbContext= new NorthwindDBContext();

            #endregion

            #region Execute Sql Query:
            // define if the Query is DQL or DML :
            #region SelectStatment
            //1- DQL: 
            //FromSqlRaw
            var categories = dbContext.Categories.FromSqlRaw("select * from Categories");
            //FromSqlInterpolated
            int count = 2;
            categories = dbContext.Categories.FromSqlInterpolated($"select top({count}) * from Categories");
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
            #endregion

            #region DML [Update , insert , delete] statments
            dbContext.Database.ExecuteSqlRaw("update Categories\r\nset CategoryName =  \'Test\'\r\nwhere CategoryID = 2 ");

            string categoryName = "candy";
            int id = 2;
            dbContext.Database.ExecuteSqlInterpolated($"update Categories\r\nset CategoryName =  {categoryName}\r\nwhere CategoryID = {id} ");

            #endregion

            #region Remote vs local:

            // loacal in cash memory

            //Remote : => each time you will send a request to the server or database to search.
            //if (dbContext.Products.Any(p => p.UnitsInStock == 0))
            //{
            //    Console.WriteLine("There is at least one product out of stock");
            //}
            // local : cash in memory:

            //first load the data in local memory
            dbContext.Products.Load();

            if(dbContext.Products.Local.Any(p => p.UnitsInStock == 0))
                Console.WriteLine("There is at least one product out of stock");
            else if (dbContext.Products.Any(p => p.UnitsInStock == 0))
                Console.WriteLine("There is at least one product out of stock");
            else
                Console.WriteLine("There is no product out of stock");


            // find take only primary key
            var result = dbContext.Products.Find(2);
            Console.WriteLine(result.ProductName);

            //find genearics
             result = dbContext.Find<Product>(3);
            Console.WriteLine(result.ProductName);

            #endregion


            #endregion


        }
    }
}
