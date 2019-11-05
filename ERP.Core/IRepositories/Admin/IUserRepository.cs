using System.Collections.Generic;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.Admin
{
    public interface IUserRepository
    {
        void Add(User user);
        void Edit(User user);
        bool Remove(int ucode);
        User FindById(int ucode);
        IEnumerable<User> GetAllUsers();
    }
}
