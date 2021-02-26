using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyCRUDBestPratices
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            
            #endregion
            #region Main Program dor SQL Department
            IDbConnection connection = new MySqlConnection(connectionString);

            DapperDepartmentsRespository repository = new DapperDepartmentsRespository(connection);
            DapperProductsRespository repository1 = new DapperProductsRespository(connection);

            Console.WriteLine("Hi There User! Great Day! Here are the current Best Buy Departments:");
            var retrieveDepartments = repository.GetAllDepartments();
            Print(retrieveDepartments);


            Console.WriteLine("User, Would you like to add a department?");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of the department you would like to create?");
                userResponse = Console.ReadLine();

                repository.InsertDepartment(userResponse);
                Print(repository.GetAllDepartments());
            }
            Console.WriteLine("Thanks for stopping by, Have A Great Day!");



            static void Print(IEnumerable<Departments> retrieveDepartments)
            {
                foreach (var item in retrieveDepartments)
                {
                    Console.WriteLine($"Id: {item.DepartmentId} Name: {item.Name}");
                }
            }
            #endregion







            Console.WriteLine("Hello User, Would you like to create a Best Buy Product!");
            var userInput = Console.ReadLine();

            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the ProductId of the product?");
                int userProductId = int.Parse(Console.ReadLine());

                Console.WriteLine("What is the Product Name?");
                string userName = Console.ReadLine();

                Console.WriteLine("What is the Price of the product?");
                decimal userPrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is the CategoryId for the new product?");
                int userCategoryId = int.Parse(Console.ReadLine());

                Console.WriteLine("Will the Product be OnSale?");
                int userOnSale = int.Parse(Console.ReadLine());

                Console.WriteLine("What is the current StockLevel for the new Product?");
                int userStockLevel = int.Parse(Console.ReadLine());

                repository1.CreateProduct(userProductId, userName, userPrice, userCategoryId, userOnSale, userStockLevel);


                Console.WriteLine("What is the name of the product created?");
                var searchInLoop = Console.ReadLine();
                var retrieveProducts1 = repository1.SearchProducts(searchInLoop);
                PrintProductInLoop(retrieveProducts1);

                static void PrintProductInLoop(IEnumerable<Products> retrieveProducts1)
                {
                    foreach (var product in retrieveProducts1)
                    {
                        Console.WriteLine($"{product.Name} has been created!");
                    }
                }



            }
            Console.WriteLine("Thanks for stopping by, Have a Great Day!");




            Console.WriteLine("Hi there User, What product would you like to search for?");
            var search = Console.ReadLine();        

            var retrieveProducts = repository1.SearchProducts(search);
            PrintProduct(retrieveProducts);

            static void PrintProduct (IEnumerable<Products> retrieveProducts)
            {
                foreach (var product in retrieveProducts)
                {
                    Console.WriteLine($"Name {product.Name}");
                }
            }
        }
            
    }
}
