using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
        public User(string name)
        {
            this.Name = name;
        }
        public User()
        {
            
        }


        public int Id {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
    }
} 