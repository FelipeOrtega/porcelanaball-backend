using System.Collections.Generic;
using PB.Domain;
using System.Linq;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public User Get_(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { username = "batman", password = "batman", role = "manager" });
            users.Add(new User { username = "robin", password = "robin", role = "employee" });
            return users.Where(x => x.username.ToLower() == username.ToLower() && x.password == password).FirstOrDefault();
        }

        public User Get(string username, string password)
        {
            User user = context.Set<User>().Where(x => x.username.ToLower() == username.ToLower() && x.password == password).FirstOrDefault();
            return user;
        }
    }
}
