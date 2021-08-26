using System.Collections.Generic;
using System;

namespace Models
{
    public class Restaurant
    {
        public Restaurant( ) {}
        public Restaurant(int id, string name, decimal avgRating, string Location)
        {
            this.Id = id;
            this.Name = name;
            this.avgRating = avgRating;
            this.Location = Location;
        }
        public Restaurant(int id, string name, string Location)
        {
            this.Id = id;
            this.Name = name;
            this.Location = Location;
            this.avgRating = 1;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal avgRating { get; set; }
    }
        
}