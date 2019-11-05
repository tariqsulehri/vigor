using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IDeptDealsInCommodityTypeRepository
    {
        void Add(DeptDealsInCommodityType deptDealsInCommodityType);
        void Edit(DeptDealsInCommodityType deptDealsInCommodityType);
        bool Remove(DeptDealsInCommodityType deptDealsInCommodityType);
        DeptDealsInCommodityType FindByKey(string key);
        bool IsDuplicate(DeptDealsInCommodityType deptDealsInCommodityType);
        IEnumerable<DeptDealsInCommodityType> GetAllDeptDealsInCommodityTypes();
        IEnumerable<DeptDealsInCommodityType> GetAllCommodityTypeByDepartment(int deptID);
        IEnumerable<DeptDealsInCommodityType> GetAllDepartmentsByCommodityTypes(int commodityTypeID);

    }
}
