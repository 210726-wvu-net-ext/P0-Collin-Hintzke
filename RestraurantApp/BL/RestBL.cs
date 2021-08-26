using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class RestBL : IRestBL
    {
        private IRestRepo _repo;

        public RestBL(IRestRepo repo)
        {
            _repo = repo;
        }
        public List<Restaurant> ViewAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }
        public User Login(string name)
        {
            return _repo.Login(name);
        }
        public User NewUser(string newName)
        {
            return _repo.NewUser(newName);
        }
        public Restaurant SearchForRestaurant(string newSearch)
        {
            return _repo.SearchForRestaurant(newSearch);
        }
        // public Restaurant ViewARestaurant(string newView)
        // {
        //     return _repo.SearchForRestaurant(newView);
        // }

        public List<Rating> GrabAllRatings(Restaurant restaurant)
        {
            return _repo.GetRatingsByRId(restaurant.Id);
        }
    }
}