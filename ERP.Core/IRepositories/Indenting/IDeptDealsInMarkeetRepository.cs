using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IDeptDealsInMarkeetRepository
    {
        void Add(DeptDealsInMarkeet deptDealsInMarkeet);
        void Edit(DeptDealsInMarkeet deptDealsInMarkeet);
        bool Remove(DeptDealsInMarkeet deptDealsInMarkeet);
        DeptDealsInMarkeet FindByKey(string key);
        bool IsDuplicate(DeptDealsInMarkeet deptDealsInMarkeet);
        IEnumerable<DeptDealsInMarkeet> GetAllDeptDealsInMarkeets();
        IEnumerable<DeptDealsInMarkeet> GetAllMarkeetByDepartment(int deptID);
        IEnumerable<DeptDealsInMarkeet> GetAllDepartmentsByMarkeets(int MarkeetID);
    }
}
