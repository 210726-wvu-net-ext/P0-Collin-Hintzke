using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal AvgRating { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
