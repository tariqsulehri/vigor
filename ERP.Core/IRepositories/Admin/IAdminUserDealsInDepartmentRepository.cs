using ERP.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Admin
{
    public interface IAdminUserDealsInDepartmentRepository
    {
           void Add(AdminUserDealsInDepartment adminUserDealsInDepartment);
          void Edit(AdminUserDealsInDepartment adminUserDealsInDepartment);
         bool Remove(AdminUserDealsInDepartment adminUserDealsInDepartment);
        AdminUserDealsInDepartment FindById(int id);
         bool IsDuplicate(AdminUserDealsInDepartment adminUserDealsInDepartment);
        IEnumerable<AdminUserDealsInDepartment> GetAllAdminUserDealsInDepartments();
    }
}
