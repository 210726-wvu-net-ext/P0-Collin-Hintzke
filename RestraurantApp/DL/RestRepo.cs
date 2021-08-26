using Models;
using System.Collections.Generic;
using System.Linq;
using System;
using DL;
using DL.Entities;




namespace DL
{
    public class RestRepo : IRestRepo
    {
        private hintrestaurantdbContext _context;
        public RestRepo(hintrestaurantdbContext context)
        {
            _context = context;
        }

        public List<Models.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.Select(
                rest => new Models.Restaurant(rest.Id, rest.Name, rest.Location)
            ).ToList();
        }

        public Models.User Login(string user)
        {
            Entities.User newUser = _context.Users
                .FirstOrDefault(player=> player.Name == user);
                if(newUser != null)
                {
                    Console.WriteLine("A user with that name has been found, Please your a password");
                    string pass = Console.ReadLine();
                    if(newUser.Pass == pass){
                        return new Models.User(newUser.Name);
                    }
                    else Console.WriteLine("Login Failed Please try again");
                    return Login(Console.ReadLine());
                    
                }
                else {
                    return NewUser(user);
                }

        }

        public Models.User NewUser(string newUser)
        {
            Console.WriteLine("Please enter a password for the new User");
            string newPass = Console.ReadLine();
            _context.Users.Add(
                    new Entities.User{
                        Name = newUser,
                        Pass = newPass
                    }
                    );
                
            _context.SaveChanges();
            return new Models.User(newUser, newPass);
        }

        public Models.Restaurant SearchForRestaurant(string newSearch)
        {
            Entities.Restaurant search = _context.Restaurants.FirstOrDefault(
                x => x.Name == newSearch);
                Console.WriteLine(search.Name);
                if(search != null)
                {

                    List<Models.Rating> list = GetRatingsByRId(search.Id);
                    double totalCount = new double();
                    totalCount = GetAvgRating(search.Id);

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(search.Name);
                    Console.WriteLine(search.Location);
                    Console.WriteLine($"Here is the average rating: {totalCount}");
                    Console.WriteLine("----------------------------------------");
                    return new Models.Restaurant(search.Id, search.Name, search.Location);
                }
                else {
                    Console.WriteLine("Restaurant not found, Please enter another name");
                    string again = Console.ReadLine();
                    return SearchForRestaurant(again);
                 }




        }

        public List<Models.Rating> GetRatingsByRId(int Id)
        {
            List<Models.Rating> list = new List<Models.Rating>();

            list = _context.Ratings
                .Where(rate => rate.RestaurantId == Id)
                .Select(rate => new Models.Rating{
                    Score = rate.Score,
                    Comment = rate.Message,



                }).ToList();
                // foreach(Models.Rating Rate in list)
                // {
                //     Console.WriteLine("-----------------------------------------------------");
                //     Console.WriteLine($"{Rate.Comment}");
                //     Console.WriteLine("-----------------------------------------------------");
                // }
                return list;
        }
        public double GetAvgRating(int RestId)
        {
            List<Models.Rating> list = GetRatingsByRId(RestId);
            double totalCount = new double();
            foreach(Models.Rating k in list)
            {
            Console.WriteLine("total Count");
            totalCount += k.Score;
            }


            return totalCount;
        }
                
     };
 }
