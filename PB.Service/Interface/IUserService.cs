using System.Collections.Generic;
using PB.Domain;

namespace PB.Service.Interface
{
    public interface IUserService
    {
        List<User> Get();
        User Get(User user);
        int Insert(User user);
        int Update(User user);
        int Delete(int codigo);
    }
}
