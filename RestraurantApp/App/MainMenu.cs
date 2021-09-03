using System;
using Models;
using System.Collections.Generic;
using DL;
using BL;
using Serilog;


namespace App
{
    public class MainMenu : IMenu
    {
        
        private IRestBL _restbl;
        private User user = new User();
        public MainMenu(IRestBL bl)
        {
            _restbl = bl;
            // Log.Logger=new LoggerConfiguration()
            //                 .MinimumLevel.Debug()
            //                 .WriteTo.Console()
            //                 .WriteTo.File("../logs/restlogs.txt", rollingInterval:RollingInterval.Day)
            //                 .CreateLogger();
            // Log.Information("UI beginning");
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Restaurant Viewer! \n");
            if(user.Name == null){
            Login();
            }
            Console.WriteLine("------------------------------------------------"); 
            Console.WriteLine($"Hello {user.Name}, what would you like to do?");
            Console.WriteLine("[1] Display All Restaurants");
            Console.WriteLine("[2] Search For A Restaurant");

            Console.WriteLine("[5] Logout");

            Console.WriteLine("[8] ADMIN ONLY: Search/View Users");
            Console.WriteLine("[9] ADMIN ONLY: Delete a Review\n----------------------------------------");

            string response = Console.ReadLine();
            if(response == "1")
            {
                ViewAllRestaurants();
                Start();
            }
            else if (response == "2")
            {
                SearchForRestaurant();
                
                
            }
            else if(response == "3")
            {

            }

        }
      private void ViewAllRestaurants() 
        {
            List<Restaurant> list = _restbl.ViewAllRestaurants();
            foreach(Restaurant rest in list)
            {
                //Console.WriteLine($"{rest.Id}");
                Console.WriteLine($"Name - {rest.Name}    Location - {rest.Location}    AverageRating - {rest.avgRating} ");
                Console.WriteLine("------------------------------------------------");
            }

         }  
         private void SearchForRestaurant()
        {
            Console.WriteLine("Please enter the name of the restaurant you would like to view");
            string nameSearch = Console.ReadLine();
            Restaurant display = _restbl.SearchForRestaurant(nameSearch);
            RestaurantOptionDisplay(display);
        }

        private User Login()
        {
            Console.WriteLine("Please enter a Username, If one does not exist, a New one will be created");
            string userName = Console.ReadLine();
            User k = _restbl.Login(userName);
            user = k;
            return k;
        }

        public void RestaurantOptionDisplay(Restaurant rest)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1]  Display all Reviews");
            Console.WriteLine("[2]  Add a Review");
            Console.WriteLine("[3]  Go back to Main Menu");
            string response = Console.ReadLine();

            if(response == "1")
            {
                List<Models.Rating> list = _restbl.GrabAllRatings(rest);
                DisplayAllRatings(list);
            }
            else if (response == "2")
            {
                
            }
            else if(response == "3")
            {

            }


        }
        public void DisplayAllRatings(List<Rating> rest)
        {
            
            foreach(Rating rate in rest)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(rate.Comment);
            }

            
        }
        
        public void End()
        {
            Console.WriteLine("Program has ended");
        }
    }   
}
