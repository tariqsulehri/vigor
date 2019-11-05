using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.Admin
{
    public interface IUserModuleDetailsRepository
    {
        void Add(UserModuleDetails userModuleDetails);
        void Edit(UserModuleDetails userModuleDetails);
        bool Remove(int id);
        UserModuleDetails FindById(int id);
        IEnumerable<UserModuleDetails> GetAllUserModuleDetails();
    }
}
