using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RestaurantId { get; set; }
        public int Score { get; set; }
        public string Message { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
    }
}
