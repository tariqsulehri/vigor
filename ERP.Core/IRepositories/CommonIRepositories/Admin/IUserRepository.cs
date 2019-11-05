using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.CommonIRepositories
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
