using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
