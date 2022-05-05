using DotNetJwtAuth.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetJwtAuth.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "user", Password = "user", Role = "User" });
            users.Add(new User { Id = 2, Username = "manager", Password = "manager", Role = "Manager" });
            users.Add(new User { Id = 3, Username = "admin", Password = "admin", Role = "Admin" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
        public static List<User> GetAll()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "user", Password = "user", Role = "User" });
            users.Add(new User { Id = 2, Username = "manager", Password = "manager", Role = "Manager" });
            users.Add(new User { Id = 3, Username = "admin", Password = "admin", Role = "Admin" });
            return users;  //.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
