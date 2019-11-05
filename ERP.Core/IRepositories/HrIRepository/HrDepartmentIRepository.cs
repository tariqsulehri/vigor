using System.Collections.Generic;
using ERP.Core.Models.Common;
using ERP.Core.Models.HR;
using ERP.Core.Models.Inventory;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface HrDepartmentIRepository
    {
        void Add(HrDepartment hrDepartment);
        void Edit(HrDepartment hrDepartment);
		bool IsDuplicate(HrDepartment hrDepartment);											
        bool Remove(int id);
        HrDepartment FindById(int id);
        IEnumerable<HrDepartment> GetAllDepartment();
    }
}
