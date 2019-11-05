using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.Admin
{
    public interface IUserModulesRepository
    {
        void Add(UserModules userModules);
        void Edit(UserModules userModules);
        bool Remove(int id);
        UserModules FindById(int id);
        IEnumerable<UserModules> GetAllUserModules();
    }
}
