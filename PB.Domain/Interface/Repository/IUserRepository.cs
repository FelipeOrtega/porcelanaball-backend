using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User Get_(string username, string password);

        public User Get(string username, string password);

    }
}
