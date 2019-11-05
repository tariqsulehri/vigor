using System.Collections.Generic;
using ERP.Core.Models.Common;
using ERP.Core.Models.HR;
using ERP.Core.Models.Inventory;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface HrEmployeeIRepository
    {
        void Add(HrEmployee hrEmployeeIRepository);
        void Edit(HrEmployee hrEmployeeIRepository);
		bool IsDuplicate(HrEmployee hrEmployee);										
        bool Remove(int id);
        HrEmployee FindById(int id);
        IEnumerable<HrEmployee> GetAllEmployees();
    }
}
