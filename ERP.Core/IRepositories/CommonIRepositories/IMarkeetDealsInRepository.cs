using ERP.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.CommonIRepositories
{
    public interface IMarkeetDealsInRepository
    {
        void Add(MarkeetDealsIn markeetDealsIn);
        void Edit(MarkeetDealsIn markeetDealsIn);
        bool Remove(MarkeetDealsIn markeetDealsIn);
        bool IsDuplicate(MarkeetDealsIn deptDealsInCommodityType);
        IEnumerable<MarkeetDealsIn> GetAllDeptDealsInCommodityTypes();
        IEnumerable<MarkeetDealsIn> GetAllCommodityTypeByDepartment(int deptID);
        IEnumerable<MarkeetDealsIn> GetAllDepartmentsByCommodityTypes(int commodityTypeID);

    }
}
