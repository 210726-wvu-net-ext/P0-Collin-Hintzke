using System.Collections.Generic;

namespace Models
{
    public class Rating
    {
        public Rating() {
            
        }
        public Rating(int Score, string User, string Comment, int RestaurantId) 
        {
            
        }
        public int Id {get; set;}
        public int Score {get; set;}
        public int User {get; set;}
        public string Comment {get; set;}
        public int RestaurantId {get; set;}

        
    }
}