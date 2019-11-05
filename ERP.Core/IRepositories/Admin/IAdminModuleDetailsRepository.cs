using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Core.IRepositories.Admin
{
   public  interface IAdminModuleDetailsRepository
    {
        void Add(AdminModuleDetails adminModuleDetails);
        void Edit(AdminModuleDetails adminModuleDetails);
        bool Remove(int id);
        AdminModuleDetails FindById(int id);
        IEnumerable<AdminModuleDetails> GetAllAdminModuleDetails();
    }
}
