using System.Collections.Generic;

using Models;

namespace DL
{
    public interface IRestRepo
    {
        List<Restaurant> GetAllRestaurants();

        User Login(string name);

        User NewUser(string newName);
        Restaurant SearchForRestaurant(string newSearch);
        List<Rating> GetRatingsByRId(int Id);
        // Retaurant ViewARestaurant(string newView);

        // Cat AddACat(Cat cat);

        // Meal AddAMeal(Meal meal);

        // Cat SearchCatByName(string name);

        // List<Meal> GetMealsByCatId(int catId);

        // void DeleteACat(Cat cat);
    }
}