using Models;
using System.Collections.Generic;
using DL;

namespace BL
{
    public interface IRestBL
    {


        List<Restaurant> ViewAllRestaurants();
        User Login(string name);
        User NewUser(string newName);
        // Restaurant ViewARestaurant(string nameSearch);
        Restaurant SearchForRestaurant(string newSearch);

        List<Rating> GrabAllRatings(Restaurant restaurant);
        // Cat AddACat(Cat cat);
        // Meal AddAMeal(Meal meal);
        // Cat SearchCatByName(string name);
        // List<Meal> GetMealsByCatId(int catId);
    }
}