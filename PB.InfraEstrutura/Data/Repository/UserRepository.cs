using System.Collections.Generic;
using PB.Domain;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, username = "batman", password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, username = "robin", password = "robin", Role = "employee" });
            return users.Where(x => x.username.ToLower() == username.ToLower() && x.password == password).FirstOrDefault();
        }
    }
}
