using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.Admin
{
    public interface IAdminModulesRepository
    {
        void Add(AdminModules adminModules);
        void Edit(AdminModules adminModules);
        bool Remove(int id);
        AdminModules FindById(int id);
        IEnumerable<AdminModules> GetAllAdminModules();
    }
}
