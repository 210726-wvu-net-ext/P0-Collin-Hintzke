using System;
using App;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DL.Entities;
using BL;
using DL;
using System.IO;


// namespace App
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Hello World!");
//         }
//     }
// }

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("hint-restaurant-db");

DbContextOptions<hintrestaurantdbContext> options = new DbContextOptionsBuilder<hintrestaurantdbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new hintrestaurantdbContext(options);

try
{
    IMenu menu = new MainMenu(new RestBL(new RestRepo(context)));
    menu.Start();
}
catch (System.Exception)
{
    
    throw;
}
